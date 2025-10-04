using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Services
{
    public class InterestEngine : IInterestEngine
    {
        private readonly AppDbContext _db;
        private const int BASIS = 365;

        public InterestEngine(AppDbContext db) => _db = db;

        public async Task AccrueDailyAsync(DateTime valueDate, CancellationToken ct = default)
        {
            // Lấy tất cả TK active
            var accts = await _db.Accounts
                .Where(a => a.Status == AccountStatus.Active)
                .ToListAsync(ct);

            foreach (var a in accts)
            {
                if (a.Balance <= 0) continue;

                var rate = await ResolveRateAsync(a, valueDate, ct); // DemandRates hoặc SavingRules
                if (rate <= 0m) continue;

                var accrual = Math.Round(a.Balance * rate * (1m / BASIS), 4); // lãi 1 ngày
                if (accrual == 0m) continue;

                _db.DailyAccruals.Add(new DailyAccrual
                {
                    AccountId = a.Id,
                    ValueDate = valueDate.Date,
                    AccruedAmount = accrual,
                    Currency = a.Currency,
                    RuleId = null, // có thể lưu rule Id nếu tra được
                    DayCountBasis = "ACT/365",
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Snapshot số dư cuối ngày phục vụ báo cáo
            foreach (var a in accts)
            {
                _db.DailyBalances.Add(new DailyBalance
                {
                    AccountId = a.Id,
                    ValueDate = valueDate.Date,
                    EndBalance = a.Balance,
                    Currency = a.Currency,
                    CreatedAt = DateTime.UtcNow
                });
            }

            await _db.SaveChangesAsync(ct);
        }

        public async Task MatureIfDueAsync(DateTime today, CancellationToken ct = default)
        {
            var due = await _db.Accounts
                .Where(a => a.AccountClass == AccountClass.Saving
                         && a.Status == AccountStatus.Active
                         && a.MaturityDate != null
                         && a.MaturityDate.Value.Date <= today.Date)
                .ToListAsync(ct);

            foreach (var a in due)
            {
                var accrued = await _db.DailyAccruals
                    .Where(x => x.AccountId == a.Id && x.ValueDate <= today.Date)
                    .SumAsync(x => x.AccruedAmount, ct);

                using var tx = await _db.Database.BeginTransactionAsync(ct);
                // Ghi giao dịch cộng lãi
                a.Balance += accrued;
                _db.Transactions.Add(new TransactionEntry
                {
                    AccountId = a.Id,
                    Type = TxType.InterestCredit,
                    Amount = accrued,
                    BalanceAfter = a.Balance,
                    Currency = a.Currency,
                    CreatedAt = DateTime.UtcNow,
                    Note = "Maturity interest credit"
                });
                await _db.SaveChangesAsync(ct);
                await tx.CommitAsync(ct);
            }
        }

        public async Task EarlyWithdrawAsync(string accountNo, decimal amount, DateTime valueDate, string? note = null, CancellationToken ct = default)
        {
            var a = await _db.Accounts.SingleAsync(x => x.AccountNo == accountNo && x.Status == AccountStatus.Active, ct);
            if (a.AccountClass != AccountClass.Saving) throw new InvalidOperationException("Chỉ áp dụng cho tiết kiệm có kỳ hạn");
            if (a.Balance < amount) throw new InvalidOperationException("Số dư không đủ");

            // Tính lãi lại theo demand rate cho toàn bộ số ngày giữ tiền:
            var open = a.OpenDate.Date;
            var days = Math.Max(1, (valueDate.Date - open).Days);
            var demandRate = await GetDemandRateAsync(a.Currency, valueDate, ct); // %/year (vd 0.005m)
            var interestEarly = Math.Round(amount * demandRate * (days / 365m), 4);

            // Tổng accrual đã ghi cho phần này (giản lược: dùng tổng accrual TK)
            var accrualToDate = await _db.DailyAccruals
                .Where(d => d.AccountId == a.Id && d.ValueDate <= valueDate.Date)
                .SumAsync(d => d.AccruedAmount, ct);

            var adjustment = interestEarly - accrualToDate; // có thể âm
            using var tx = await _db.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, ct);

            // Ghi điều chỉnh lãi (nếu khác 0)
            if (adjustment != 0m)
            {
                a.Balance += adjustment;
                _db.Transactions.Add(new TransactionEntry
                {
                    AccountId = a.Id,
                    Type = TxType.Adjustment,
                    Amount = adjustment,
                    BalanceAfter = a.Balance,
                    Currency = a.Currency,
                    CreatedAt = DateTime.UtcNow,
                    Note = "Early withdrawal interest adjustment"
                });
            }

            // Ghi rút tiền
            a.Balance -= amount;
            _db.Transactions.Add(new TransactionEntry
            {
                AccountId = a.Id,
                Type = TxType.Withdraw,
                Amount = amount,
                BalanceAfter = a.Balance,
                Currency = a.Currency,
                CreatedAt = DateTime.UtcNow,
                Note = note
            });

            await _db.SaveChangesAsync(ct);
            await tx.CommitAsync(ct);
        }

        private async Task<decimal> ResolveRateAsync(Account a, DateTime d, CancellationToken ct)
        {
            if (a.AccountClass == AccountClass.Checking)
                return await GetDemandRateAsync(a.Currency, d, ct);

            // Saving: tìm rule theo term và hiệu lực
            var term = a.SavingTermMonths ?? 0;
            var rule = await _db.InterestRules
                .Where(r => r.AccountClass == AccountClass.Saving
                         && r.TermFromM <= term && r.TermToM >= term
                         && r.EffectiveFrom <= d
                         && (r.EffectiveTo == null || r.EffectiveTo >= d))
                .OrderByDescending(r => r.EffectiveFrom)
                .FirstOrDefaultAsync(ct);

            return rule?.Rate ?? 0m;
        }

        private async Task<decimal> GetDemandRateAsync(string ccy, DateTime d, CancellationToken ct)
            => await _db.DemandRates
                .Where(r => r.Currency == ccy && r.EffectiveFrom <= d
                         && (r.EffectiveTo == null || r.EffectiveTo >= d))
                .OrderByDescending(r => r.EffectiveFrom)
                .Select(r => r.Rate)
                .FirstOrDefaultAsync(ct);
    }

}
