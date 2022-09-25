using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {  
            if (!content.Category.Any())
            content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                     new Car
                     {
                         name = "Tesla",
                         shortDesc = "Быстрый автомобиль",
                         longDesc = "Красивый, быстрый, тихий, надежный",
                         img = "/img/1.jpg",
                         price = 45000,
                         isFavourite = true,
                         available = true,
                         Category = Categories["Электроавтомобили"]
                     },
                     new Car
                     {
                         name = "Tesla S",
                         shortDesc = "Быстрый и компактный автомобиль",
                         longDesc = "Красивый, быстрый, тихий, надежный и небольшой",
                         img = "/img/2.jpg",
                         price = 43000,
                         isFavourite = false,
                         available = true,
                         Category = Categories["Электроавтомобили"]
                     },
                      new Car
                      {
                          name = "Таврия",
                          shortDesc = "Супер машина",
                          longDesc = "Не нуждается в представлении",
                          img = "/img/3.jpg",
                          price = 1000,
                          isFavourite = true,
                          available = true,
                          Category = Categories["Классические автомобили"]
                      },
                       new Car
                       {
                           name = "Таврия Славута",
                           shortDesc = "Супер машина",
                           longDesc = "Не нуждается в представлении",
                           img = "/img/4.jpg",
                           price = 1100,
                           isFavourite = false,
                           available = true,
                           Category = Categories["Классические автомобили"]
                       }
                );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "Электроавтомобили", desc = "Современный вид транспорта"},
                        new Category {categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего згорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);

                }

                return category;
            } 
        }
    }
}
