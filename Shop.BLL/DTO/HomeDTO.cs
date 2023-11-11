using Shop.DAL.Models;

namespace Shop.BLL.DTO
{
    public class HomeDTO
    {
        public IEnumerable<Car> TopSellingCars { get; set; }
    }
}
