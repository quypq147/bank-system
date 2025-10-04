namespace BankApi.Models
{
    public class DailyBalance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public DateTime ValueDate { get; set; }
        public decimal EndBalance { get; set; }
        public string Currency { get; set; } = "VND";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
