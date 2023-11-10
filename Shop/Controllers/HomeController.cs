using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Intefaces;
using Shop.Services;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shop.DAL.Repository;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork Database;
        public HomeController(UnitOfWork database)
        {
            Database = database;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeDTO
            {
                FavCars = Database.Cars.GetSelectedCars
            };
            return View(homeCars);
        }

        public IActionResult Car(int id) => View(Database.Cars.Get(id));
    }
}
