namespace BankApi.Models
{
    public class DemandRate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Currency { get; set; } = "VND";
        public decimal Rate { get; set; }            // 0.0025m = 0.25%/năm
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
