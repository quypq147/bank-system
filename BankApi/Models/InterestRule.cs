namespace BankApi.Models
{
    public class InterestRule
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public AccountClass AccountClass { get; set; } = AccountClass.Saving;
        public int TermFromM { get; set; }           // tháng
        public int TermToM { get; set; }             // tháng
        public decimal Rate { get; set; }            // ví dụ 0.055m = 5.5%/năm
        public string RateType { get; set; } = "Nominal";
        public InterestPayout Payout { get; set; } = InterestPayout.EndOfTerm;
        public bool IsDefault { get; set; } = true;
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
