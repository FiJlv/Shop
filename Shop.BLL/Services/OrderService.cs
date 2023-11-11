using Shop.DAL.Models;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class OrderService
    {
        private readonly AppDBContext appDBContent;
        private readonly ShopCartService shopCart;

        public OrderService(AppDBContext appDBContent, ShopCartService shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void Create(Order order)
        {
            order.OrderTime = DateTime.UtcNow;
            appDBContent.Orders.Add(order);
            appDBContent.SaveChanges();

            var shopItems = shopCart.ListShopItems;

            foreach (var item in shopItems)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };
                appDBContent.OrderDetails.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
