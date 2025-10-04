using BankApi.Models;

namespace BankApi.Services
{
    public interface IAccountService
    {
        Task<Account> OpenAsync(Guid customerId, AccountClass accountClass, string currency = "VND");
        Task DepositAsync(string accountNo, decimal amount, string? memo = null);
        Task WithdrawAsync(string accountNo, decimal amount, string? memo = null);
        Task TransferAsync(string fromAccountNo, string toAccountNo, decimal amount, string? memo = null);
        Task<Account?> GetByNoAsync(string accountNo);
        Task<IReadOnlyList<TransactionEntry>> GetStatementAsync(string accountNo, DateTime from, DateTime to);
    }
}
