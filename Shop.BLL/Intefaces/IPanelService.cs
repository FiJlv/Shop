using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Intefaces
{
    public interface IPanelService
    {
        IEnumerable<Car> GetAllCars();
        CarDTO GetCarViewModel(int id);
        Task<bool> SaveCar(CarDTO vm);
        Task RemoveCar(int id);
    }
}
