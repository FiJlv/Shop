using Shop.DAL.Models;

namespace Shop.BLL.DTO
{
    public class HomeDTO
    {
        public IEnumerable<Car> FavCars { get; set; }
    }
}
