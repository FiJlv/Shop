using Microsoft.EntityFrameworkCore;
using Shop.DAL.Interfaces;
using Shop.DAL.Models;

namespace Shop.DAL.Repository
{
    public class CarRepository : IRepository<Car>
    {
        private readonly AppDBContext appDBContext;

        public CarRepository(AppDBContext appDBContent)
        {
            this.appDBContext = appDBContent;
        }

        public IEnumerable<Car> GetCarsByCategory(string category)
        {
            return appDBContext.Cars
           .Where(i => i.Category.CategoryName.Equals(category))
           .OrderBy(i => i.Id);
        }

        public IEnumerable<Car> GetAll()
        {
            return appDBContext.Cars.OrderBy(i => i.Id);
        }

        public Car Get(int id)
        {
            return appDBContext.Cars.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Car car)
        {
            appDBContext.Cars.Add(car);
        }

        public void Update(Car car)
        {
            appDBContext.Cars.Update(car);
        }

        public void Delete(int id)
        {
            appDBContext.Cars.Remove(Get(id));
        }

        //?
        public IEnumerable<Car> Cars => appDBContext.Cars.Include(c => c.Category);

        //?
        public IEnumerable<Car> GetSelectedCars => appDBContext.Cars.Where(p => p.IsFavourite).Include(c => c.Category);

        public List<Car> GetFavoriteCarsForUser(string userId)
        {
            var user = appDBContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);
            return user?.FavoriteCars.ToList() ?? new List<Car>();
        }

        public void AddFavoriteCarForUser(string userId, Car car)
        {

            var user = appDBContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);

            if (user != null && car != null && !user.FavoriteCars.Any(c => c.Id == car.Id))
            {
                user.FavoriteCars.Add(car);
                appDBContext.SaveChanges();
            }
        }

        public void RemoveFavoriteCarForUser(string userId, int carId)
        {
            var user = appDBContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var carToRemove = user.FavoriteCars.FirstOrDefault(c => c.Id == carId);
                if (carToRemove != null)
                {
                    user.FavoriteCars.Remove(carToRemove);
                    appDBContext.SaveChanges();
                }
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await appDBContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
