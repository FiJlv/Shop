using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Data;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IAllCars _carRep;

        public PanelController(IAllCars carRep)
        {
            _carRep = carRep;
        }
        public IActionResult Index()
        {
            var cars = _carRep.Cars;
            return View(cars);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
                return View(new Car());
            else
            {
                var car = _carRep.GetObjectCar(id);
                return View(car);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            if (car.Id > 0)
                _carRep.UpdateCar(car);
            else
                _carRep.AddCar(car);

            if (await _carRep.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(car);
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _carRep.RemoveCar(id);
            await _carRep.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
