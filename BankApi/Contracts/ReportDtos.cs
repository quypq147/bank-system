using BankApi.Models;

namespace BankApi.Contracts
{
    public record TransactionFilter(DateTime From, DateTime To, string? AccountNo, string? Type, string? Currency);
    public record AccountQuery(string? No, AccountClass? Class, int? Term, DateTime? OpenedFrom, DateTime? OpenedTo, AccountStatus? Status);
    public record DailyBalanceQuery(DateTime Date, string? Currency);
    public record TxRow(DateTime CreatedAt, string AccountNo, string Type, decimal Amount, string Currency, decimal BalanceAfter, string? Note);
    public record AccountsByTypeRow(AccountClass AccountClass, int? SavingTermMonths, string Currency, int CountAcc, decimal TotalBalance);
    public record DailyBalanceRow(DateTime ValueDate, string Currency, decimal TotalBalance);
    public class ReportDtos
    {
    }
}
