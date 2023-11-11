using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.BLL.Services;
using Shop.BLL.DTO;

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private const string myIndex = "Index";

        private readonly AdminPanelService adminPanelService;

        public AdminPanelController(AdminPanelService adminPanelService)
        {
            this.adminPanelService = adminPanelService;
        }

        public IActionResult Index()
        {
            var cars = adminPanelService.GetAllCars();
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
                var carViewModel = adminPanelService.GetCarViewModel((int)id);
                return View(carViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarDTO vm)
        {
            if (await adminPanelService.SaveCar(vm))
                return RedirectToAction(myIndex);
            else
                return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            await adminPanelService.RemoveCar(id);
            return RedirectToAction(myIndex);
        }
    }
}
