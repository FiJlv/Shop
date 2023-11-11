using Microsoft.EntityFrameworkCore;
using Shop.DAL.Models;

namespace Shop.DAL.Repository
{
    public class UnitOfWork
    {
        private AppDBContext db;
        private CarRepository carRepository;
        private CategoryRepository categoryRepository;

        public UnitOfWork(DbContextOptions<AppDBContext> options)
        {
            db = new AppDBContext(options);
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
