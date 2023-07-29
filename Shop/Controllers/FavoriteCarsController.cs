using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    public class FavoriteCarsController : Controller
    {
        private readonly AppDBContext _dbContext;

        public FavoriteCarsController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _dbContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var favoriteCars = user.FavoriteCars.ToList();
                return View(favoriteCars);
            }

            return View(new List<Car>());
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _dbContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);
            var car = _dbContext.Cars.Find(id);

            if (user != null && car != null)
            {
                bool carAlreadyAdded = user.FavoriteCars.Any(c => c.Id == car.Id);

                if (!carAlreadyAdded)
                {
                    user.FavoriteCars.Add(car);
                    _dbContext.SaveChanges();
                }
                else
                {
                    Remove(id); 
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _dbContext.Users.Include(u => u.FavoriteCars).FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var carToRemove = user.FavoriteCars.FirstOrDefault(c => c.Id == id);
                if (carToRemove != null)
                {
                    user.FavoriteCars.Remove(carToRemove);
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
