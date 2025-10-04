// Controllers/AccountsController.cs
using BankApi.Contracts;
using BankApi.Data;
using BankApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Mặc định cần đăng nhập
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _svc;
        private readonly AppDbContext _db;

        public AccountsController(IAccountService svc, AppDbContext db)
        {
            _svc = svc;
            _db = db;
        }

        /// <summary>
        /// Admin mở tài khoản cho khách bất kỳ.
        /// </summary>
        [HttpPost("open")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AccountDto>> Open([FromBody] AccountOpenDto dto, CancellationToken ct)
        {
            if (dto.CustomerId == Guid.Empty)
                return BadRequest("CustomerId is required.");

            if (string.IsNullOrWhiteSpace(dto.Currency))
                return BadRequest("Currency is required.");

            var acc = await _svc.OpenAsync(dto.CustomerId, dto.AccountClass, dto.Currency);

            return CreatedAtAction(nameof(GetByNo), new { accountNo = acc.AccountNo },
                new AccountDto(
                    acc.Id,
                    acc.AccountNo,
                    acc.AccountClass,
                    acc.Balance,
                    acc.Currency,
                    acc.Status,
                    acc.SavingTermMonths,
                    acc.InterestPayout
                ));
        }

        /// <summary>
        /// Xem chi tiết tài khoản. Customer chỉ xem được tài khoản của chính mình.
        /// </summary>
        [HttpGet("{accountNo}")]
        public async Task<ActionResult<AccountDto>> GetByNo(string accountNo, CancellationToken ct)
        {
            var a = await _svc.GetByNoAsync(accountNo);
            if (a is null) return NotFound();

            // Nếu không phải Admin → phải đúng chủ tài khoản
            if (!User.IsInRole("Admin") && !IsOwnedByCurrentCustomer(a.CustomerId))
                return Forbid();

            return new AccountDto(
                a.Id,
                a.AccountNo,
                a.AccountClass,
                a.Balance,
                a.Currency,
                a.Status,
                a.SavingTermMonths,
                a.InterestPayout
            );
        }

        /// <summary>
        /// Nạp tiền. Customer chỉ nạp vào tài khoản của chính mình.
        /// </summary>
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] CashDto dto, CancellationToken ct)
        {
            if (dto.Amount <= 0) return BadRequest("Amount must be positive.");

            await EnsureAccountOwnedOrAdmin(dto.AccountNo);
            await _svc.DepositAsync(dto.AccountNo, dto.Amount, dto.Note);
            return Ok();
        }

        /// <summary>
        /// Rút tiền. Customer chỉ rút từ tài khoản của chính mình.
        /// </summary>
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] CashDto dto, CancellationToken ct)
        {
            if (dto.Amount <= 0) return BadRequest("Amount must be positive.");

            await EnsureAccountOwnedOrAdmin(dto.AccountNo);
            await _svc.WithdrawAsync(dto.AccountNo, dto.Amount, dto.Note);
            return Ok();
        }

        /// <summary>
        /// Chuyển tiền. Customer chỉ được chuyển từ tài khoản của chính mình.
        /// </summary>
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferDto dto, CancellationToken ct)
        {
            if (dto.Amount <= 0) return BadRequest("Amount must be positive.");
            if (string.Equals(dto.FromAccountNo, dto.ToAccountNo, StringComparison.OrdinalIgnoreCase))
                return BadRequest("FromAccountNo and ToAccountNo must be different.");

            await EnsureAccountOwnedOrAdmin(dto.FromAccountNo);
            await _svc.TransferAsync(dto.FromAccountNo, dto.ToAccountNo, dto.Amount, dto.Note);
            return Ok();
        }

        /// <summary>
        /// Sao kê. Customer chỉ xem được tài khoản của chính mình.
        /// </summary>
        [HttpPost("statement")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> Statement([FromBody] StatementQueryDto dto, CancellationToken ct)
        {
            if (dto.From > dto.To) return BadRequest("From must be <= To.");

            await EnsureAccountOwnedOrAdmin(dto.AccountNo);

            var list = await _svc.GetStatementAsync(dto.AccountNo, dto.From, dto.To);
            return Ok(list.Select(t => new TransactionDto(t.CreatedAt, t.Type, t.Amount, t.BalanceAfter, t.RefId)));
        }

        // -------------------- Helpers --------------------

        private bool IsOwnedByCurrentCustomer(Guid accountCustomerId)
        {
            // Admin bỏ qua kiểm tra sở hữu
            if (User.IsInRole("Admin")) return true;

            var cid = User.FindFirstValue("customer_id");
            return cid != null && Guid.TryParse(cid, out var current) && current == accountCustomerId;
        }

        private async Task EnsureAccountOwnedOrAdmin(string accountNo)
        {
            if (User.IsInRole("Admin")) return;

            var acc = await _svc.GetByNoAsync(accountNo);
            if (acc is null) throw new KeyNotFoundException("Account not found");

            if (!IsOwnedByCurrentCustomer(acc.CustomerId))
                throw new UnauthorizedAccessException("You do not own this account.");
        }
        [HttpGet("/api/customers/{customerId:guid}/accounts")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsOfCustomer(Guid customerId)
        {
            // Nếu không phải admin → chỉ được lấy tài khoản của chính mình
            if (!User.IsInRole("Admin"))
            {
                var cid = User.FindFirstValue("customer_id");
                if (cid is null || !Guid.TryParse(cid, out var current) || current != customerId)
                    return Forbid();
            }

            var accounts = await _db.Accounts
                .Where(a => a.CustomerId == customerId)
                .OrderByDescending(a => a.CreatedAt)
                .Select(a => new AccountDto(
                    a.Id,
                    a.AccountNo,
                    a.AccountClass,
                    a.Balance,
                    a.Currency,
                    a.Status,
                    a.SavingTermMonths,
                    a.InterestPayout
                )).ToListAsync();

            return Ok(accounts); // Có thể rỗng nếu chưa mở tài khoản
        }
    }
}


