using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.BLL.Intefaces;
using Shop.Services;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository carRepository;
        public HomeController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeDTO
            {
                FavCars = carRepository.GetFavCars
            };
            return View(homeCars);
        }

        public IActionResult Car(int id) => View(carRepository.GetObjectCar(id));
    }
}
