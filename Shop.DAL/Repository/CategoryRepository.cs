using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext appDBContent;

        public CategoryRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return appDBContent.Categories;
        }

        public Category GetCategoryByName(string categoryName)
        {
            return appDBContent.Categories.FirstOrDefault(c => c.CategoryName.Equals(categoryName));
        }
    }

}
