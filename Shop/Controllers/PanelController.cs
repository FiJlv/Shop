using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shop.DAL.Repository;
using Shop.Data.FileManager;
using Shop.Data.Models;
using Shop.Services;
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
        private const string MyIndex = "Index";

        private readonly PanelService panelService;

        public PanelController(UnitOfWork database, IFileManager fileManager)
        {
            panelService = new PanelService(database, fileManager);
        }

        public IActionResult Index()
        {
            var cars = panelService.GetAllCars();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new CarDTO());
            }
            else
            {
                var carViewModel = panelService.GetCarViewModel((int)id);
                return View(carViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarDTO vm)
        {
            if (await panelService.SaveCar(vm))
                return RedirectToAction(MyIndex);
            else
                return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            await panelService.RemoveCar(id);
            return RedirectToAction(MyIndex);
        }
    }
}
