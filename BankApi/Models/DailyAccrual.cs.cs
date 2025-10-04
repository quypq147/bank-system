namespace BankApi.Models
{
    public class DailyAccrual
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public DateTime ValueDate { get; set; }      // ngày hạch toán
        public decimal AccruedAmount { get; set; }   // lãi 1 ngày
        public string Currency { get; set; } = "VND";
        public Guid? RuleId { get; set; }
        public string DayCountBasis { get; set; } = "ACT/365";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
