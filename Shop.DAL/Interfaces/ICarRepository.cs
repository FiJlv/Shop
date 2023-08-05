using Microsoft.Extensions.Hosting;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetFavCars { get;}
        IEnumerable<Car> GetCarsByCategory(string category);
        Car GetObjectCar(int carId);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void RemoveCar(int id);
        Task<bool> SaveChangesAsync();
    }
}
