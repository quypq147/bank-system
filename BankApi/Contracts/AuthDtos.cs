using BankApi.Contracts;
using BankApi.Data;
using BankApi.Models; // ApplicationUser

namespace BankApi.Contracts
{
    public record RegisterDto(string Email, string Password , string CustomerId  );
    public record LoginDto(string Email, string Password);

    public class AuthDtos
    {
    }
}
