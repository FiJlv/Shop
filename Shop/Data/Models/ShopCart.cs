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
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCarItem> listShopItems { get; set; }        

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCarId);
            return new ShopCart(context) { ShopCartId = shopCarId };
        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCarItem.Add(new ShopCarItem {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCarItem> getShopItems()
        {
            return appDBContent.ShopCarItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
