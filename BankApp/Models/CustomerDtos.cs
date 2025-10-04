using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Models
{
    public class CustomerCreateDto { public string FullName { get; set; } public string Email { get; set; } public string Phone { get; set; } public string Address { get; set; } }
    public class CustomerDto { public string Id { get; set; } public string FullName { get; set; } public string Email { get; set; } public string Phone { get; set; } public string Address { get; set; } }
    internal class CustomerDtos
    {
    }
}
