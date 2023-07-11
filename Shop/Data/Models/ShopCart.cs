using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContext appDBContent;

        public ShopCart(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCarItem> ListShopItems { get; set; }        

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCarId);
            return new ShopCart(context) { ShopCartId = shopCarId };
        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCarItem.Add(new ShopCarItem {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            appDBContent.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = appDBContent.ShopCarItem.Where(c => c.ShopCartId == ShopCartId);
            appDBContent.ShopCarItem.RemoveRange(cartItems);
            appDBContent.SaveChanges();
        }

        public void RemoveFromCart(int itemId)
        {
            var cartItem = appDBContent.ShopCarItem.FirstOrDefault(c => c.Id == itemId && c.ShopCartId == ShopCartId);
            if (cartItem != null)
            {
                appDBContent.ShopCarItem.Remove(cartItem);
                appDBContent.SaveChanges();
            }
        }

        public List<ShopCarItem> GetShopItems()
        {
            return appDBContent.ShopCarItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
