using FoodManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FoodManagementCore.Services
{
    public interface IFood
    {
        List<Food> GetFood(int? categoryID);
        Food Save(Food food);
        bool Update(Food food);
        bool Delete(int foodID);
    }
    public class FoodService : IFood
    {
        public FoodManagementContext _dbContext;
        public FoodService(FoodManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Delete(int foodID)
        {
            try
            {
                _dbContext.Remove(_dbContext.Foods.Single(f => f.FoodID == foodID));
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        public List<Food> GetFood(int? categoryID)
        {
            if (categoryID is null)
            {
                var foods = _dbContext.Foods.ToList();
                foreach (Food item in foods)
                {
                    item.Category = _dbContext.Categories
                        .Where(c => c.CategoryID == item.CategoryID).SingleOrDefault();
                }
                return foods;
            }
            else
            {
                return _dbContext.Foods.Where(f => f.Category.CategoryID == categoryID).ToList();
            }
        }
        public Food Save(Food food)
        {
            _dbContext.Foods.Add(food);
            _dbContext.SaveChanges();
            food.FoodID = food.FoodID;
            return food;

        }
        public bool Update(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
