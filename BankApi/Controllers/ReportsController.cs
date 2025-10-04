using BankApi.Contracts;
using BankApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BankApi.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize] // cả Admin & Customer (Customer xem dữ liệu của mình)
public class ReportsController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly UserManager<ApplicationUser> _users;
    public ReportsController(AppDbContext db, UserManager<ApplicationUser> users) { _db = db; _users = users; }

    private async Task<Guid?> GetCustomerIdIfCustomerAsync()
    {
        var user = await _users.GetUserAsync(User);
        if (user == null) return null;
        if (await _users.IsInRoleAsync(user, "Admin")) return null;
        return user.CustomerId; // ApplicationUser liên kết Customer
    }

    [HttpGet("transactions")]
    public async Task<ActionResult<IEnumerable<TxRow>>> Transactions([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string? accountNo, [FromQuery] string? type, [FromQuery] string? currency)
    {
        var custId = await GetCustomerIdIfCustomerAsync();

        var q = from t in _db.Transactions
                join a in _db.Accounts on t.AccountId equals a.Id
                select new { t, a };

        if (custId.HasValue) q = q.Where(x => x.a.CustomerId == custId.Value);
        if (!string.IsNullOrWhiteSpace(accountNo)) q = q.Where(x => x.a.AccountNo == accountNo);
        if (!string.IsNullOrWhiteSpace(type)) q = q.Where(x => x.t.Type.ToString() == type);
        if (!string.IsNullOrWhiteSpace(currency)) q = q.Where(x => x.t.Currency == currency);
        q = q.Where(x => x.t.CreatedAt >= from && x.t.CreatedAt <= to).OrderBy(x => x.t.CreatedAt);

        var rows = await q.Select(x => new TxRow(x.t.CreatedAt, x.a.AccountNo, x.t.Type.ToString(), x.t.Amount, x.t.Currency, x.t.BalanceAfter, x.t.Note)).ToListAsync();
        return rows;
    }

    [HttpGet("accounts-by-type")]
    public async Task<ActionResult<IEnumerable<AccountsByTypeRow>>> AccountsByType([FromQuery] AccountClass? @class, [FromQuery] int? term)
    {
        var custId = await GetCustomerIdIfCustomerAsync();
        var q = _db.Accounts.AsQueryable().Where(a => a.Status == AccountStatus.Active);
        if (custId.HasValue) q = q.Where(a => a.CustomerId == custId.Value);
        if (@class.HasValue) q = q.Where(a => a.AccountClass == @class);
        if (term.HasValue) q = q.Where(a => a.SavingTermMonths == term);

        var rows = await q.GroupBy(a => new { a.AccountClass, a.SavingTermMonths, a.Currency })
            .Select(g => new AccountsByTypeRow(g.Key.AccountClass, g.Key.SavingTermMonths, g.Key.Currency, g.Count(), g.Sum(x => x.Balance)))
            .OrderBy(r => r.AccountClass).ThenBy(r => r.SavingTermMonths).ToListAsync();
        return rows;
    }

    [HttpGet("daily-balance")]
    public async Task<ActionResult<IEnumerable<DailyBalanceRow>>> DailyBalance([FromQuery] DateTime date, [FromQuery] string? currency)
    {
        var custId = await GetCustomerIdIfCustomerAsync();
        var q = from d in _db.DailyBalances
                join a in _db.Accounts on d.AccountId equals a.Id
                where d.ValueDate == date.Date
                select new { d, a };

        if (custId.HasValue) q = q.Where(x => x.a.CustomerId == custId.Value);
        if (!string.IsNullOrWhiteSpace(currency)) q = q.Where(x => x.d.Currency == currency);

        var rows = await q.GroupBy(x => new { x.d.ValueDate, x.d.Currency })
            .Select(g => new DailyBalanceRow(g.Key.ValueDate, g.Key.Currency, g.Sum(x => x.d.EndBalance)))
            .OrderBy(r => r.Currency).ToListAsync();
        return rows;
    }
}

