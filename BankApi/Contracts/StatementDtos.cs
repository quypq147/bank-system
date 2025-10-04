using BankApi.Models;

namespace BankApi.Contracts
{
    public record StatementQueryDto(string AccountNo, DateTime From, DateTime To);
    public record TransactionDto(DateTime CreatedAt, TxType Type, decimal Amount, decimal BalanceAfter, string? RefId);
    public class StatementDtos
    {
    }
}
