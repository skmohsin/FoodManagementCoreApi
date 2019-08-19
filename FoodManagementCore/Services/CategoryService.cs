using FoodManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodManagementCore.Services
{
    public interface ICategory
    {
        List<Category> GetCategory();
        Category Save(Category category);
        bool Update(Category category);
        bool Delete(int categoryID);
    }
    public class CategoryService : ICategory
    {
        public FoodManagementContext _dbContext;
        public CategoryService(FoodManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Delete(int categoryID)
        {
            try
            {
                _dbContext.Remove(_dbContext.Categories.Single(c => c.CategoryID == categoryID));
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        public List<Category> GetCategory()
        {
            return _dbContext.Categories.ToList();
        }
        public Category Save(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            category.CategoryID = category.CategoryID;
            return category;

        }
        public bool Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
