using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDBContext appDBContext;

        public CarRepository(AppDBContext appDBContent)
        {   
            this.appDBContext = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDBContext.Cars.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => appDBContext.Cars.FirstOrDefault(p => p.Id == carId);
        public void AddCar(Car car)
        {
            appDBContext.Cars.Add(car);
        }

        public void RemoveCar(int id)
        {
            appDBContext.Cars.Remove(GetObjectCar(id));
        }
        public void UpdateCar(Car car)
        {
            appDBContext.Cars.Update(car);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await appDBContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Car> GetCarsByCategory(string category)
        {
            return appDBContext.Cars
           .Where(i => i.Category.CategoryName.Equals(category))
           .OrderBy(i => i.Id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return appDBContext.Cars.OrderBy(i => i.Id);
        }
    }
}
