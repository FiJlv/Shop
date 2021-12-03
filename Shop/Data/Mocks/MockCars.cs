using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {

        private readonly ICarsCategory _categoryCars = new MockCategory(); 
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Красивый, быстрый, тихий, надежный!!! ПОКУПАЙТЕ!!!",
                        img = "/img/1.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true, 
                        Category = _categoryCars.AllCategories.First()
                    },
                     new Car
                    {
                        name = "Tesla S",
                        shortDesc = "Быстрый и компактный автомобиль",
                        longDesc = "Красивый, быстрый, тихий, надежный и небольшой!!! ПОКУПАЙТЕ!!!",
                        img = "/img/2.jpg",
                        price = 43000,
                        isFavourite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                      new Car
                    {
                        name = "Таврия",
                        shortDesc = "Супер машина",
                        longDesc = "Не нуждается в представлении, берите, не пожалеете!",
                        img = "/img/3.jpg",
                        price = 1000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                       new Car
                    {
                        name = "Таврия Славута",
                        shortDesc = "Норм машинка",
                        longDesc = "Как и стандартная Таврия, не нуждается в представлении, берите, не пожалеете!",
                        img = "/img/4.jpg",
                        price = 1100,
                        isFavourite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
