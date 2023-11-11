using Shop.DAL.Interfaces;
using Shop.DAL.Models;


namespace Shop.DAL.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext appDBContent)
        {
            this.appDBContext = appDBContent;
        }

        public void Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByName(string categoryName)
        {
            return appDBContext.Categories.FirstOrDefault(c => c.CategoryName.Equals(categoryName));
        }

        public IEnumerable<Category> GetAll()
        {
            return appDBContext.Categories;
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
