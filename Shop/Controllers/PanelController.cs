using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shop.Data.FileManager;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IAllCars carRep;
        private readonly IFileManager fileManager;

        public PanelController(IAllCars carRep, IFileManager fileManager)
        {
            this.carRep = carRep;
            this.fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var cars = carRep.Cars;
            return View(cars);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new CarViewModel());
            }
            else
            {
                var car = carRep.GetObjectCar((int)id);
                return View(new CarViewModel
                {
                    Id = car.Id,
                    Name = car.Name,
                    ShortDesc = car.ShortDesc,
                    LongDesc = car.LongDesc,
                    CurrentImage = car.Image,
                    Price = car.Price,
                    IsFavourite = car.IsFavourite,
                    Available = car.Available,
                    CategoryID = car.CategoryID
                    
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel vm)
        {
            var car = new Car
            {
                Id = vm.Id,
                Name = vm.Name,
                ShortDesc = vm.ShortDesc,
                LongDesc = vm.LongDesc,
                Price = vm.Price,
                IsFavourite = vm.IsFavourite,
                Available = vm.Available,
                CategoryID = vm.CategoryID
            };

            if (vm.Image == null)
                car.Image = vm.CurrentImage;
            else
            {
                if (!string.IsNullOrEmpty(vm.CurrentImage))
                    fileManager.RemoveImage(vm.CurrentImage);

                car.Image = await fileManager.SaveImage(vm.Image);
            }

            if (car.Id > 0)
                carRep.UpdateCar(car);
            else
                carRep.AddCar(car);

            if (await carRep.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            carRep.RemoveCar(id);
            await carRep.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
