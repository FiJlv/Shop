using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Electric cars", Desc = "A modern and economical mode of transportation"},
                    new Category {CategoryName = "Gasoline cars", Desc = "Internal combustion engine vehicles"} 
                };
            }      
        }
    }
}
