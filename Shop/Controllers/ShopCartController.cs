using Microsoft.AspNetCore.Mvc;
using Shop.DAL.Repository; //
using Shop.DAL.Models; //
using System.Linq;
using Shop.BLL.DTO;

namespace Shop.Controllers
{
    public class ShopCartController: Controller
    {
        private const string MyIndex = "Index";
        UnitOfWork Database;
        private readonly ShopCart shopCart;
        public ShopCartController(UnitOfWork database, ShopCart shopCart)
        {
            Database = database;
            this.shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = shopCart.GetShopItems();
            shopCart.ListShopItems = items;

            var obj = new ShopCartDTO
            {
                ShopCart = shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = Database.Cars.GetAll().FirstOrDefault(i => i.Id == id); 
            if(item != null)
            {
                shopCart.AddToCart(item);          
            }
            return RedirectToAction(MyIndex);
        }

        public IActionResult RemoveFromCart(int id)
        {
            shopCart.RemoveFromCart(id);
            return RedirectToAction(MyIndex);
        }
    }
}
