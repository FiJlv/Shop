using Shop.BLL.Intefaces;
using Shop.DAL.Repository;
using Shop.DAL.Models;
using Shop.BLL.DTO;

namespace Shop.BLL.Services
{
    public class CarService: ICarService
    {
        private UnitOfWork database; 

        public CarService(UnitOfWork database)
        {
            this.database = database;
        }

        public CarsListDTO GetCarsListViewModel(string category)
        {
            category ??= string.Empty;

            IEnumerable<Car> cars = string.IsNullOrEmpty(category)
                ? database.Cars.GetAll()
                : database.Cars.GetCarsByCategory(category);

            var currCategory = string.IsNullOrEmpty(category)
            ? string.Empty
                : database.Categories.GetCategoryByName(category)?.CategoryName ?? "";

            var carObj = new CarsListDTO
            {
                AllCars = cars,
                CurrentCategory = currCategory
            };

            return carObj;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return database.Cars.GetAll();
        }
        public List<Car> GetFavoriteCarsForUser(string userId)
        {
            return database.Cars.GetFavoriteCarsForUser(userId);
        }

        public IEnumerable<Car> GetTopSellingCars()
        {
            return database.Cars.TopSellingCars;
        }

        public void AddFavoriteCarForUser(string userId, Car car)
        {
            database.Cars.AddFavoriteCarForUser(userId, car);
        }

        public void RemoveFavoriteCarForUser(string userId, int carId)
        {
            database.Cars.RemoveFavoriteCarForUser(userId, carId);
        }

        public Car GetCarById(int id)
        {
            return database.Cars.Get(id);
        }

    }
}
