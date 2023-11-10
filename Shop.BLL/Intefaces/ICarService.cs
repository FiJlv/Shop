using Shop.BLL.DTO;

namespace Shop.BLL.Intefaces
{
    public interface ICarService
    {
        CarsListDTO GetCarsListViewModel(string category);
    }
}
