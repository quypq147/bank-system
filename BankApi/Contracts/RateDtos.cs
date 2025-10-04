using BankApi.Models;

namespace BankApi.Contracts
{
    public record DemandRateDto(string Currency, decimal Rate, DateTime EffectiveFrom);
    public record InterestRuleDto(AccountClass AccountClass, int TermFromM, int TermToM, decimal Rate, InterestPayout Payout, DateTime EffectiveFrom, DateTime? EffectiveTo);
    public record FxRateDto(string QuoteCurrency, decimal Mid, DateTime EffectiveFrom);
    public class RateDtos
    {
    }
}
