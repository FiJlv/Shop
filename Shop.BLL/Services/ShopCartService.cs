using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shop.DAL.Models;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.BLL.Services
{
    public class ShopCartService
    {
        public string ShopCartId { get; set; }
        public List<ShopCarItem> ListShopItems { get; set; }
        private readonly AppDBContext appDBContext;

        public ShopCartService(AppDBContext appDBContent)
        {
            this.appDBContext = appDBContent;
        }

        public static ShopCartService GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCarId);

            return new ShopCartService(context) { ShopCartId = shopCarId };
        }

        public void AddToCart(Car car)
        {
            appDBContext.Cars.Attach(car);

            appDBContext.ShopCarItems.Add(new ShopCarItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            appDBContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = appDBContext.ShopCarItems.Where(c => c.ShopCartId == ShopCartId);
            appDBContext.ShopCarItems.RemoveRange(cartItems);
            appDBContext.SaveChanges();
        }

        public List<ShopCarItem> GetShopItems()
        {
            return appDBContext.ShopCarItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }

        public void RemoveFromCart(int itemId)
        {
            var cartItem = appDBContext.ShopCarItems.FirstOrDefault(c => c.Id == itemId && c.ShopCartId == ShopCartId);
            if (cartItem != null)
            {
                appDBContext.ShopCarItems.Remove(cartItem);
                appDBContext.SaveChanges();
            }
        }
    }
}
