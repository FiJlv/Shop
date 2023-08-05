using Shop.BLL.Intefaces;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Services
{
    public class FavoriteCarsService: IFavoriteCarsService
    {
        private readonly IFavoriteCarsRepository _favoriteCarsRepository;

        public FavoriteCarsService(IFavoriteCarsRepository favoriteCarsRepository)
        {
            _favoriteCarsRepository = favoriteCarsRepository;
        }

        public List<Car> GetFavoriteCarsForUser(string userId)
        {
            return _favoriteCarsRepository.GetFavoriteCarsForUser(userId);
        }

        public void AddFavoriteCarForUser(string userId, Car car)
        {
            _favoriteCarsRepository.AddFavoriteCarForUser(userId, car);
        }

        public void RemoveFavoriteCarForUser(string userId, int carId)
        {
            _favoriteCarsRepository.RemoveFavoriteCarForUser(userId, carId);
        }
    }
}
