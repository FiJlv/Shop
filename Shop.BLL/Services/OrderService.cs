using Shop.DAL.Models;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.DTO;
using AutoMapper;

namespace Shop.BLL.Services
{
    public class OrderService
    {
        private readonly AppDBContext appDBContent;
        private readonly ShopCartService shopCart;
        private readonly IMapper mapper;

        public OrderService(AppDBContext appDBContent, ShopCartService shopCart, IMapper mapper)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
            this.mapper = mapper;
        }

        public void Create(OrderDTO orderDTO)
        {
            Order order = mapper.Map<Order>(orderDTO);

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
