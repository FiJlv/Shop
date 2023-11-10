using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.BLL.Services;
using Shop.BLL.DTO;

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private const string MyIndex = "Index";

        private readonly PanelService panelService;

        public PanelController(PanelService panelService)
        {
            this.panelService = panelService;
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
