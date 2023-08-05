using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly AppDBContext appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContext appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

       public void CreateOrder(Order order)
       {
            order.OrderTime = DateTime.Now;
            appDBContent.Orders.Add(order);
            appDBContent.SaveChanges();

            var shopItems = shopCart.ListShopItems; 

            foreach(var item in shopItems)
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
