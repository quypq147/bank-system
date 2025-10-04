namespace BankApi.Models
{
    public enum AccountType { Checking, Saving }
    public enum AccountStatus { Active, Frozen, Closed }

    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public string AccountNo { get; set; } = default!;
        public AccountClass AccountClass { get; set; } = AccountClass.Checking;
        public int? SavingTermMonths { get; set; }
        public InterestPayout? InterestPayout { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "VND";
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public DateTime OpenDate { get; set; } = DateTime.UtcNow;
        public DateTime? MaturityDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
        public ICollection<TransactionEntry> Transactions { get; set; } = new List<TransactionEntry>();
    }
}
