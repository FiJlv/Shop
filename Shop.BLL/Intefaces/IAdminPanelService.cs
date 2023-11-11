using Shop.BLL.DTO;
using Shop.DAL.Models;

namespace Shop.BLL.Intefaces
{
    public interface IAdminPanelService
    {
        IEnumerable<Car> GetAllCars();
        CarDTO GetCarViewModel(int id);
        Task<bool> SaveCar(CarDTO vm);
        Task RemoveCar(int id);
    }
}
