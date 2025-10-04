using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Models
{
    public class RegisterDto { public string Email { get; set; } public string Password { get; set; } }
    public class LoginDto { public string Email { get; set; } public string Password { get; set; } }
    public class LoginResult { public string token { get; set; } }
    internal class AuthDtos
    {
    }
}
