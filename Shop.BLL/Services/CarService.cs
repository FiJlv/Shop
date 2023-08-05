using Shop.BLL.Intefaces;
using Shop.Data.FileManager;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CarService: ICarService
    {
        private readonly ICarRepository carRepository;
        private readonly ICategoryRepository categoryRepository;

        public CarService(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            this.carRepository = carRepository;
            this.categoryRepository = categoryRepository;
        }

        public CarsListDTO GetCarsListViewModel(string category)
        {
            category ??= string.Empty;

            IEnumerable<Car> cars = string.IsNullOrEmpty(category)
                ? carRepository.GetAllCars()
                : carRepository.GetCarsByCategory(category);

            var currCategory = string.IsNullOrEmpty(category)
            ? string.Empty
                : categoryRepository.GetCategoryByName(category)?.CategoryName ?? "";

            var carObj = new CarsListDTO
            {
                AllCars = cars,
                CurrCategory = currCategory
            };

            return carObj;
        }    
    }
}
