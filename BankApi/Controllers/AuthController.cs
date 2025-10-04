// Controllers/AuthController.cs
using BankApi.Contracts;
using BankApi.Data; // ApplicationUser
using BankApi.Models; // Customer
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _users;
    private readonly RoleManager<IdentityRole> _roles;
    private readonly IConfiguration _cfg;
    private readonly AppDbContext _db;

    public AuthController(UserManager<ApplicationUser> users, RoleManager<IdentityRole> roles, IConfiguration cfg, AppDbContext db)
    { _users = users; _roles = roles; _cfg = cfg; _db = db; }

    [HttpPost("register")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // Nếu muốn link vào Customer đã có, thêm trường CustomerId vào RegisterDto
        Customer customer;

        if (!string.IsNullOrWhiteSpace(dto.CustomerId) && Guid.TryParse(dto.CustomerId, out var cid))
        {
            customer = await _db.Customers.FindAsync(cid) ?? throw new("Customer not found");
        }
        else
        {
            // tạo mới Customer tối thiểu
            customer = new Customer { FullName = dto.Email, Email = dto.Email };
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
        }

        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            EmailConfirmed = true,
            CustomerId = customer.Id
        };
        var res = await _users.CreateAsync(user, dto.Password);
        if (!res.Succeeded) return BadRequest(res.Errors);

        await _users.AddToRoleAsync(user, "Customer");
        return Ok(new { message = "Customer user created", customerId = customer.Id, userId = user.Id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _users.FindByEmailAsync(dto.Email);
        if (user == null || !(await _users.CheckPasswordAsync(user, dto.Password))) return Unauthorized();

        var roles = await _users.GetRolesAsync(user);
        var token = CreateToken(user, roles);
        Console.WriteLine($"[LOGIN OK] Token: {token}");
        return Ok(new { token });
    }

    private string CreateToken(ApplicationUser user, IList<string> roles)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
        };

        if (user.CustomerId.HasValue)
            claims.Add(new Claim("customer_id", user.CustomerId.Value.ToString()));

        foreach (var r in roles)
            claims.Add(new Claim(ClaimTypes.Role, r)); // rất quan trọng để [Authorize(Roles="...")] hoạt động

        var jwt = new JwtSecurityToken(
            issuer: _cfg["Jwt:Issuer"],
            audience: _cfg["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    [HttpGet("me")]
    [Authorize]
    public IActionResult Me()
    {
        var name = User.Identity?.Name ?? "(no name)";
        var sub = User.Claims.FirstOrDefault(c => c.Type.EndsWith("/nameidentifier"))?.Value;
        var roles = User.Claims.Where(c => c.Type == System.Security.Claims.ClaimTypes.Role).Select(c => c.Value);
        var cid = User.Claims.FirstOrDefault(c => c.Type == "customer_id")?.Value;
        return Ok(new { name, sub, roles, customer_id = cid });
    }
}


