using Shop.DAL.Models;

namespace Shop.BLL.DTO
{
    public class CarsListDTO
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrCategory { get; set; }
    }
}
