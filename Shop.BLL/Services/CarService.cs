using Shop.BLL.Intefaces;
using Shop.DAL.Repository;
using Shop.DAL.Models;
using Shop.BLL.DTO;

namespace Shop.BLL.Services
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
        
        public List<Car> GetFavoriteCarsForUser(string userId)
        {
            return Database.Cars.GetFavoriteCarsForUser(userId);
        }

        public IEnumerable<Car> GetSelectedCars()
        {
            return Database.Cars.GetSelectedCars;
        }

        public void AddFavoriteCarForUser(string userId, Car car)
        {
            Database.Cars.AddFavoriteCarForUser(userId, car);
        }

        public void RemoveFavoriteCarForUser(string userId, int carId)
        {
            Database.Cars.RemoveFavoriteCarForUser(userId, carId);
        }

        public Car Get(int id)
        {
            return Database.Cars.Get(id);
        }

    }
}
