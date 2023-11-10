using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Repository;
using Shop.Data;
using Shop.Data.FileManager;
using Shop.Data.Repository;
using Shop.Services;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService carsService;
        private AppDBContext appDBContext;
        private UnitOfWork Database;

        public CarsController(CarService carsService, UnitOfWork database)
        {
            this.carsService = carsService;
            Database = database;
        }

        [Route("Cars/List/{category?}")]
        public ViewResult List(string category)
        {
            var carObj = carsService.GetCarsListViewModel(category);

            ViewBag.Title = "Page with cars";

            return View(carObj);
        }

        public IActionResult FavoriteCars()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var favoriteCars = Database.Cars.GetFavoriteCarsForUser(userId);

            return View(favoriteCars);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var car = Database.Cars.Get(id);

            if (car != null)
            {
                Database.Cars.AddFavoriteCarForUser(userId, car);
            }

            return RedirectToAction("FavoriteCars");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Database.Cars.RemoveFavoriteCarForUser(userId, id);

            return RedirectToAction("FavoriteCars");
        }
    }
}
