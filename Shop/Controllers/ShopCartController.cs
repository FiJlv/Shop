using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllCars carRep;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            this.carRep = carRep;
            this.shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = shopCart.GetShopItems();
            shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = carRep.Cars.FirstOrDefault(i => i.Id == id); 
            if(item != null)
            {
                shopCart.AddToCart(item);
                
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            shopCart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

    }
}
