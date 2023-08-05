using Microsoft.AspNetCore.Mvc;
using Shop.Data.FileManager;
using Shop.Data.Interfaces;
using Shop.Services;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService carsManager;

        public CarsController(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            carsManager = new CarService(carRepository, categoryRepository);
        }

        [Route("Cars/List/{category?}")]
        public ViewResult List(string category)
        {
            var carObj = carsManager.GetCarsListViewModel(category);

            ViewBag.Title = "Page with cars";

            return View(carObj);
        }
    }
}
