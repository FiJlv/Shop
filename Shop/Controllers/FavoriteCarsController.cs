using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Shop.Services;

namespace Shop.Controllers
{
    public class FavoriteCarsController : Controller
    {
        private const string MyIndex = "Index";

        private readonly AppDBContext _dbContext;
        private readonly FavoriteCarsService _favoriteCarsService;

        public FavoriteCarsController(AppDBContext dbContext, FavoriteCarsService favoriteCarsService)
        {
            _dbContext = dbContext;
            _favoriteCarsService = favoriteCarsService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var favoriteCars = _favoriteCarsService.GetFavoriteCarsForUser(userId);

            return View(favoriteCars);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var car = _dbContext.Cars.Find(id);

            if (car != null)
            {
                _favoriteCarsService.AddFavoriteCarForUser(userId, car);
            }

            return RedirectToAction(MyIndex);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _favoriteCarsService.RemoveFavoriteCarForUser(userId, id);

            return RedirectToAction(MyIndex);
        }
    }
}
