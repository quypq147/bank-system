using BankApi.Contracts;
using BankApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RatesController : ControllerBase
{
    private readonly AppDbContext _db;
    public RatesController(AppDbContext db) => _db = db;

    [HttpGet("demand")]
    public async Task<ActionResult<DemandRateDto>> GetDemand([FromQuery] string currency)
    {
        var now = DateTime.UtcNow;
        var rate = await _db.DemandRates
            .Where(r => r.Currency == currency && r.EffectiveFrom <= now && (r.EffectiveTo == null || r.EffectiveTo >= now))
            .OrderByDescending(r => r.EffectiveFrom).FirstOrDefaultAsync();
        if (rate == null) return NotFound();
        return new DemandRateDto(rate.Currency, rate.Rate, rate.EffectiveFrom);
    }

    [HttpGet("saving-rules")]
    public async Task<ActionResult<IEnumerable<InterestRuleDto>>> GetSavingRules([FromQuery] AccountClass @class = AccountClass.Saving, [FromQuery] int? term = null)
    {
        var q = _db.InterestRules.AsQueryable().Where(r => r.AccountClass == @class);
        if (term.HasValue) q = q.Where(r => r.TermFromM <= term && r.TermToM >= term);
        var list = await q.OrderByDescending(r => r.EffectiveFrom)
            .Select(r => new InterestRuleDto(r.AccountClass, r.TermFromM, r.TermToM, r.Rate, r.Payout, r.EffectiveFrom, r.EffectiveTo))
            .ToListAsync();
        return list;
    }

    // ----- ADMIN: Create/Update -----
    [HttpPost("demand")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateDemand(DemandRateDto dto)
    {
        _db.DemandRates.Add(new DemandRate { Currency = dto.Currency, Rate = dto.Rate, EffectiveFrom = dto.EffectiveFrom });
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("saving-rules")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateSavingRule(InterestRuleDto dto)
    {
        _db.InterestRules.Add(new InterestRule
        {
            AccountClass = dto.AccountClass,
            TermFromM = dto.TermFromM,
            TermToM = dto.TermToM,
            Rate = dto.Rate,
            Payout = dto.Payout,
            EffectiveFrom = dto.EffectiveFrom,
            EffectiveTo = dto.EffectiveTo,
            IsDefault = true
        });
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("fx")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateFx(FxRateDto dto)
    {
        _db.FxRates.Add(new FxRate { QuoteCurrency = dto.QuoteCurrency, Mid = dto.Mid, EffectiveFrom = dto.EffectiveFrom });
        await _db.SaveChangesAsync();
        return Ok();
    }
}

