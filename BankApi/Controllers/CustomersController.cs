// Controllers/CustomersController.cs
using BankApi.Contracts;
using BankApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _db;
    public CustomersController(AppDbContext db) { _db = db; }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create(CustomerCreateDto dto)
    {
        var c = new Customer { FullName = dto.FullName, Email = dto.Email, Phone = dto.Phone, Address = dto.Address };
        _db.Customers.Add(c); await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = c.Id },
            new CustomerDto(c.Id, c.FullName, c.Email, c.Phone, c.Address));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> GetById(Guid id)
    {
        var c = await _db.Customers.FindAsync(id);
        return c is null ? NotFound() : new CustomerDto(c.Id, c.FullName, c.Email, c.Phone, c.Address);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Search([FromQuery] string? q)
    {
        var query = _db.Customers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q)) query = query.Where(x => x.FullName.Contains(q) || x.Email.Contains(q));
        var data = await query.OrderByDescending(x => x.CreatedAt)
            .Select(c => new CustomerDto(c.Id, c.FullName, c.Email, c.Phone, c.Address)).ToListAsync();
        return Ok(data);
    }
}

