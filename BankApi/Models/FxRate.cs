namespace BankApi.Models
{
    public class FxRate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string BaseCurrency { get; set; } = "VND";
        public string QuoteCurrency { get; set; } = "USD";
        public decimal Mid { get; set; }             // 25400.0000
        public decimal? Bid { get; set; }
        public decimal? Ask { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
