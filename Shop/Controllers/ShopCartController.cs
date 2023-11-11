using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Shop.BLL.DTO;
using Shop.BLL.Services;

namespace Shop.Controllers
{
    public class ShopCartController: Controller
    {
        private const string myIndex = "Index";
        private readonly ShopCartService shopCart;
        private CarService carService;
        public ShopCartController(CarService carService, ShopCartService shopCart)
        {
            this.shopCart = shopCart;
            this.carService = carService;
        }

        public ViewResult Index()
        {
            var items = shopCart.GetShopItems();
            shopCart.ListShopItems = items;

            var obj = new ShopCartDTO
            {
                ShopCartService = shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = carService.GetAllCars().FirstOrDefault(i => i.Id == id); 
            if(item != null)
            {
                shopCart.AddToCart(item);          
            }
            return RedirectToAction(myIndex);
        }

        public IActionResult RemoveFromCart(int id)
        {
            shopCart.RemoveFromCart(id);
            return RedirectToAction(myIndex);
        }
    }
}
