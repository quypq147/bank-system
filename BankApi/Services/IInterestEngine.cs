using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public interface IInterestEngine
    {
        Task AccrueDailyAsync(DateTime valueDate, CancellationToken ct = default);
        Task MatureIfDueAsync(DateTime today, CancellationToken ct = default);
        Task EarlyWithdrawAsync(string accountNo, decimal amount, DateTime valueDate, string? note = null, CancellationToken ct = default);
    }
}

