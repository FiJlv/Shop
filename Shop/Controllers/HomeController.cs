using Microsoft.AspNetCore.Mvc;
using Shop.BLL.DTO;
using Shop.BLL.Services;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        CarService carService;
        public HomeController(CarService carService)
        {
            this.carService = carService;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeDTO
            {
                TopSellingCars = carService.GetTopSellingCars()
            };
            return View(homeCars);
        }

        public IActionResult Car(int id) => View(carService.GetCarById(id));
    }
}
