using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.FileManager;
using Shop.Data.Interfaces;
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
        private readonly CarService carsManager;
        AppDBContext appContext;
        ICarRepository carRepository;

        public CarsController(ICarRepository carRepository, ICategoryRepository categoryRepository, AppDBContext appContext)
        {
            carsManager = new CarService(carRepository, categoryRepository);
            this.appContext = appContext;
            this.carRepository = carRepository;
        }

        [Route("Cars/List/{category?}")]
        public ViewResult List(string category)
        {
            var carObj = carsManager.GetCarsListViewModel(category);

            ViewBag.Title = "Page with cars";

            return View(carObj);
        }

        public IActionResult FavoriteCars()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var favoriteCars = carRepository.GetFavoriteCarsForUser(userId);

            return View(favoriteCars);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var car = appContext.Cars.Find(id);

            if (car != null)
            {
                carRepository.AddFavoriteCarForUser(userId, car);
            }

            return RedirectToAction("FavoriteCars");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            carRepository.RemoveFavoriteCarForUser(userId, id);

            return RedirectToAction("FavoriteCars");
        }
    }
}
