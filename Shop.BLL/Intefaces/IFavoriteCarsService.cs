using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Intefaces
{
    public interface IFavoriteCarsService
    {
        List<Car> GetFavoriteCarsForUser(string userId);
        void AddFavoriteCarForUser(string userId, Car car);
        void RemoveFavoriteCarForUser(string userId, int carId);
    }
}
