using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars carRep;
        public HomeController(IAllCars carRep)
        {
            this.carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = carRep.GetFavCars
            };
            return View(homeCars);
        }

        public IActionResult Car(int id) => View(carRep.GetObjectCar(id));
    }
}
