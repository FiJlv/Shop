using Shop.BLL.Intefaces;
using Shop.DAL.Repository;
using Shop.Data.FileManager;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CarService: ICarService
    {
        UnitOfWork Database; 

        public CarService(UnitOfWork database)
        {
            Database = database;
        }

        public CarsListDTO GetCarsListViewModel(string category)
        {
            category ??= string.Empty;

            IEnumerable<Car> cars = string.IsNullOrEmpty(category)
                ? Database.Cars.GetAll()
                : Database.Cars.GetCarsByCategory(category);

            var currCategory = string.IsNullOrEmpty(category)
            ? string.Empty
                : Database.Categories.GetCategoryByName(category)?.CategoryName ?? "";

            var carObj = new CarsListDTO
            {
                AllCars = cars,
                CurrCategory = currCategory
            };

            return carObj;
        }    
    }
}
