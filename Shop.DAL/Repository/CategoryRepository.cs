using Microsoft.EntityFrameworkCore;
using Shop.DAL.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDBContext appDBContent;

        public CategoryRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public void Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        //Remove, search by ID
        public Category GetCategoryByName(string categoryName)
        {
            return appDBContent.Categories.FirstOrDefault(c => c.CategoryName.Equals(categoryName));
        }

        public IEnumerable<Category> GetAll()
        {
            return appDBContent.Categories;
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

}
