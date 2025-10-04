using BankApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Guid? CustomerId { get; set; }  // nếu là khách hàng gắn với 1 Customer record
        public Customer? Customer { get; set; }
    }
}
