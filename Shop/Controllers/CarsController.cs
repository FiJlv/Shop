using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Services;
using System.Security.Claims;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService carsService;

        public CarsController(CarService carsService)
        {
            this.carsService = carsService;
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
            var favoriteCars = carsService.GetFavoriteCarsForUser(userId);

            return View(favoriteCars);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var car = carsService.Get(id);

            if (car != null)
            {
                carsService.AddFavoriteCarForUser(userId, car);
            }

            return RedirectToAction("FavoriteCars");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            carsService.RemoveFavoriteCarForUser(userId, id);

            return RedirectToAction("FavoriteCars");
        }
    }
}
