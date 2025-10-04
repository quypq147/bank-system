using BankApi.Models;

namespace BankApi.Contracts
{
    public record AccountOpenDto(
    Guid CustomerId,
    AccountClass AccountClass,     // <-- thay vì Type
    string Currency,
    int? TermMonths = null,
    InterestPayout? Payout = null
    );
    public record AccountDto(
    Guid Id,
    string AccountNo,
    AccountClass AccountClass,     // <-- thay vì Type
    decimal Balance,
    string Currency,
    AccountStatus Status,
    int? SavingTermMonths,
    InterestPayout? InterestPayout
);
    public record TransferDto(string FromAccountNo, string ToAccountNo, decimal Amount, string? Note);
    public record CashDto(string AccountNo, decimal Amount, string? Note);
    public class AccountDtos
    {
    }
}
