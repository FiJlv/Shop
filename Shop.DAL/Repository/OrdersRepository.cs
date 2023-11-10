using Shop.DAL.Interfaces;
using Shop.DAL.Models;

namespace Shop.DAL.Repository
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly AppDBContext appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContext appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void Create(Order order)
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
