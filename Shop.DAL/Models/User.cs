using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class User : IdentityUser
    {
        public string Surname { get; set; }
        public string Address { get; set; }
        public ICollection<Car> FavoriteCars { get; set; }
        public User()
        {
            FavoriteCars = new List<Car>();
        }
    }
}
