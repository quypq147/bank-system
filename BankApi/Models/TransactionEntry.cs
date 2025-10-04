namespace BankApi.Models
{
    public enum TxType { Deposit, Withdraw, TransferIn, TransferOut, Fee, Interest , InterestCredit,
        Adjustment
    }
    public class TransactionEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public TxType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string? RefId { get; set; }
        public string? Note { get; set; }
        public string Currency { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
