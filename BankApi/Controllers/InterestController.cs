using BankApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] // chỉ Admin chạy batch
public class InterestController : ControllerBase
{
    private readonly IInterestEngine _engine;
    public InterestController(IInterestEngine engine) => _engine = engine;

    [HttpPost("accrue")]
    public async Task<IActionResult> Accrue([FromQuery] DateTime? date = null, CancellationToken ct = default)
    {
        var d = (date ?? DateTime.UtcNow.Date);
        await _engine.AccrueDailyAsync(d, ct);
        return Ok(new { message = "accrued", date = d });
    }

    [HttpPost("mature-due")]
    public async Task<IActionResult> MatureDue([FromQuery] DateTime? date = null, CancellationToken ct = default)
    {
        var d = (date ?? DateTime.UtcNow.Date);
        await _engine.MatureIfDueAsync(d, ct);
        return Ok(new { message = "matured", date = d });
    }
}

