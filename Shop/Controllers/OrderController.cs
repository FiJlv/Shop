using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DAL.Models;
using System;
using System.Threading.Tasks;
using Shop.BLL.Services;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShopCartService shopCart;
        private readonly UserManager<User> userManager;
        private readonly OrderService orderService;
        public OrderController(ShopCartService shopCart, OrderService orderService, UserManager<User> userManager)
        {
            this.shopCart = shopCart;
            this.userManager = userManager;
            this.orderService = orderService;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {        
            shopCart.ListShopItems = shopCart.GetShopItems();      

            if(shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You must have goods");
            }

            if (ModelState.IsValid)
            {
                orderService.Create(order);
                shopCart.ClearCart();
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public async Task<IActionResult> CheckoutForAuthenticatedUser(string name)
        {
            if (User.Identity.IsAuthenticated)
            {

                User user = await userManager.FindByNameAsync(name);

                var order = new Order
                {
                    Name = user.UserName,
                    Surname = user.Surname,
                    Address = user.Address,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    OrderTime = DateTime.Now
                };

                Checkout(order);

            }
            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order successfully processed";
            return View(); 
        }
    }
}
