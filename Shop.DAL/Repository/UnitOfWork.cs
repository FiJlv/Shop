using Microsoft.EntityFrameworkCore;
using Shop.DAL.Models;

namespace Shop.DAL.Repository
{
    public class UnitOfWork
    {
        private AppDBContext db;
        private readonly ShopCart shopCart;
        private CarRepository carRepository;
        private CategoryRepository categoryRepository;
        private OrdersRepository ordersRepository;

        public UnitOfWork(DbContextOptions<AppDBContext> options, ShopCart shopCart)
        {
            db = new AppDBContext(options);
            this.shopCart = shopCart;
        }

        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public OrdersRepository Orders
        {
            get
            {
                if (ordersRepository == null)
                    ordersRepository = new OrdersRepository(db, shopCart);
                return ordersRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
