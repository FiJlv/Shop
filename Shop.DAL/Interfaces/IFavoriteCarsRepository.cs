using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IFavoriteCarsRepository
    {
        List<Car> GetFavoriteCarsForUser(string userId);
        void AddFavoriteCarForUser(string userId, Car car);
        void RemoveFavoriteCarForUser(string userId, int carId);
    }
}
