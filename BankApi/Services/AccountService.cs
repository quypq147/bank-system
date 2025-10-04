using BankApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BankApi.Services
{
    // Services/IAccountService.cs
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _db;
        public AccountService(AppDbContext db) => _db = db;

        public async Task<Account> OpenAsync(Guid customerId, AccountClass accountClass, string currency = "VND")
        {
            var customer = await _db.Customers.FindAsync(customerId) ?? throw new("Customer not found");
            var acc = new Account
            {
                CustomerId = customerId,
                AccountClass = accountClass,
                Currency = currency,
                AccountNo = GenerateAccountNo()
            };
            _db.Accounts.Add(acc);
            await _db.SaveChangesAsync();
            return acc;
        }

        // Existing method retained for compatibility with AccountType
        public async Task<Account> OpenAsync(Guid customerId, AccountType type, string currency = "VND")
        {
            var customer = await _db.Customers.FindAsync(customerId) ?? throw new("Customer not found");
            var acc = new Account
            {
                CustomerId = customerId,
                AccountClass = AccountClass.Checking,
                Currency = currency,
                AccountNo = GenerateAccountNo()
            };
            _db.Accounts.Add(acc);
            await _db.SaveChangesAsync();
            return acc;
        }

        public async Task<Account?> GetByNoAsync(string accountNo) =>
            await _db.Accounts.SingleOrDefaultAsync(a => a.AccountNo == accountNo);

        public async Task DepositAsync(string accountNo, decimal amount, string? memo = null)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be > 0");

            var acc = await _db.Accounts.SingleAsync(a => a.AccountNo == accountNo && a.Status == AccountStatus.Active);

            using var tx = await _db.Database.BeginTransactionAsync();

            acc.Balance += amount;

            _db.Transactions.Add(new TransactionEntry
            {
                AccountId = acc.Id,
                Amount = amount,
                Type = TxType.Deposit,
                BalanceAfter = acc.Balance,
                Currency = acc.Currency,   // ✅ Thêm dòng này để tránh NULL
                RefId = memo
            });

            await _db.SaveChangesAsync();
            await tx.CommitAsync();
        }

        public async Task WithdrawAsync(string accountNo, decimal amount, string? memo = null)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be > 0");
            var acc = await _db.Accounts.SingleAsync(a => a.AccountNo == accountNo && a.Status == AccountStatus.Active);
            if (acc.Balance < amount) throw new InvalidOperationException("Insufficient balance");
            using var tx = await _db.Database.BeginTransactionAsync();
            acc.Balance -= amount;
            _db.Transactions.Add(new TransactionEntry
            {
                AccountId = acc.Id,
                Amount = amount,
                Type = TxType.Withdraw,
                BalanceAfter = acc.Balance,
                Currency = acc.Currency,   // ✅ Thêm dòng này để tránh NULL
                RefId = memo
            });
            await _db.SaveChangesAsync();
            await tx.CommitAsync();
        }

        public async Task TransferAsync(string fromNo, string toNo, decimal amount, string? memo = null)
        {
            if (fromNo == toNo) throw new ArgumentException("Same account");
            if (amount <= 0) throw new ArgumentException("Amount must be > 0");

            using var scope = await _db.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);

            var from = await _db.Accounts.SingleAsync(a => a.AccountNo == fromNo && a.Status == AccountStatus.Active);
            var to = await _db.Accounts.SingleAsync(a => a.AccountNo == toNo && a.Status == AccountStatus.Active);

            if (from.Balance < amount) throw new InvalidOperationException("Insufficient balance");

            from.Balance -= amount;
            to.Balance += amount;

            var refId = Guid.NewGuid().ToString("N");
            _db.Transactions.AddRange(
                new TransactionEntry { AccountId = from.Id, Amount = amount, Type = TxType.TransferOut, BalanceAfter = from.Balance, RefId = refId },
                new TransactionEntry { AccountId = to.Id, Amount = amount, Type = TxType.TransferIn, BalanceAfter = to.Balance, RefId = refId }
            );

            await _db.SaveChangesAsync();
            await scope.CommitAsync();
        }

        public async Task<IReadOnlyList<TransactionEntry>> GetStatementAsync(string accountNo, DateTime from, DateTime to)
        {
            var acc = await _db.Accounts.SingleAsync(a => a.AccountNo == accountNo);
            return await _db.Transactions
                .Where(t => t.AccountId == acc.Id && t.CreatedAt >= from && t.CreatedAt <= to)
                .OrderBy(t => t.CreatedAt)
                .ToListAsync();
        }

        private static string GenerateAccountNo() => DateTime.UtcNow.ToString("yyyy") + Random.Shared.Next(10000000, 99999999);
    }

}
