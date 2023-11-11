using Microsoft.AspNetCore.Http;
using Shop.DAL.Models;

namespace Shop.BLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public uint Price { get; set; }
        public bool TopSellingCars { get; set; }
        public bool Available { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string CurrentImage { get; set; } = "";
        public IFormFile Image { get; set; } = null;
    }
}
