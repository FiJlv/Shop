using Microsoft.AspNetCore.Identity;

namespace Shop.Data.Models
{
    public class User : IdentityUser
    {
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
