using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class FavoriteCarsRepository : IFavoriteCarsRepository
    {
        private readonly AppDBContext _dbContext;

        public FavoriteCarsRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Car> GetFavoriteCarsForUser(string userId)
        {
            var user = _dbContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);
            return user?.FavoriteCars.ToList() ?? new List<Car>();
        }

        public void AddFavoriteCarForUser(string userId, Car car)
        {

            var user = _dbContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);

            if (user != null && car != null && !user.FavoriteCars.Any(c => c.Id == car.Id))
            {
                user.FavoriteCars.Add(car);
                _dbContext.SaveChanges();
            }
        }

        public void RemoveFavoriteCarForUser(string userId, int carId)
        {
            var user = _dbContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var carToRemove = user.FavoriteCars.FirstOrDefault(c => c.Id == carId);
                if (carToRemove != null)
                {
                    user.FavoriteCars.Remove(carToRemove);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
