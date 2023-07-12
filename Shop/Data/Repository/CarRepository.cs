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
    public class CarRepository : IAllCars
    {
        private readonly AppDBContext appDBContent;

        public CarRepository(AppDBContext appDBContent)
        {   
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Cars.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDBContent.Cars.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => appDBContent.Cars.FirstOrDefault(p => p.Id == carId);
        public void AddCar(Car car)
        {
            appDBContent.Cars.Add(car);
        }

        public void RemoveCar(int id)
        {
            appDBContent.Cars.Remove(GetObjectCar(id));
        }
        public void UpdateCar(Car car)
        {
            appDBContent.Cars.Update(car);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await appDBContent.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
