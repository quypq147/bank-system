using System;

namespace BankClient.Models
{
    // ---- Enums khớp với server ----
    public enum AccountClass { Checking = 0, Saving = 1 }
    public enum AccountStatus { Active = 0, Frozen = 1, Closed = 2 }
    public enum InterestPayout { EndOfTerm = 0, Monthly = 1 }

    // ---- DTO mở tài khoản ----
    public class AccountOpenDto
    {
        public string CustomerId { get; set; }            // Guid dạng string
        public AccountClass AccountClass { get; set; }    // thay cho Type
        public string Currency { get; set; } = "VND";
        public int? TermMonths { get; set; }              // nullable, nếu Saving thì có thể set
        public InterestPayout? Payout { get; set; }       // nullable, nếu Saving thì có thể set
    }

    // ---- DTO tài khoản ----
    public class AccountDto
    {
        public string Id { get; set; }
        public string AccountNo { get; set; }
        public AccountClass AccountClass { get; set; }    // thay cho Type
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public AccountStatus Status { get; set; }
        public int? SavingTermMonths { get; set; }        // thêm
        public InterestPayout? InterestPayout { get; set; } // thêm
        public DateTime OpenedAt { get; internal set; }
    }

    // ---- Giao dịch / Sao kê ----
    public enum TxType
    {
        Deposit, Withdraw,
        TransferIn, TransferOut,
        Fee,
        Interest,           // nếu server còn dùng
        InterestCredit,     // cộng lãi khi đáo hạn
        Adjustment          // điều chỉnh lãi khi rút trước hạn
        // (có thể bổ sung InterestAccrual, Maturity nếu server dùng)
    }

    public class TransferDto
    {
        public string FromAccountNo { get; set; }
        public string ToAccountNo { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
    }

    public class CashDto
    {
        public string AccountNo { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
    }

    public class StatementQueryDto
    {
        public string AccountNo { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class TransactionDto
    {
        public DateTime CreatedAt { get; set; }
        public TxType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string RefId { get; set; }
        // (tuỳ chọn) public string Note { get; set; }
    }
}

