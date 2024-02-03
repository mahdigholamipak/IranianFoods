using IranianFoods.Models;
using System.Linq.Expressions;

namespace IranianFoods.Services
{
    public interface IFoodRepository:IRepository<Food>
    {
        public Food GetFood(int? Id);
        public Task<Food> GetFoodAsync(int? Id);
        public ICollection<Food> GetAllFoods();
        public Task<ICollection<Food>> GetAllFoodsAsync();
        public ICollection<Food> FindFoods(Expression<Func<Food, bool>> predicate);
        public Task<ICollection<Food>> FindFoodsAsync(Expression<Func<Food, bool>> predicate);

        public void AddFood(Food food);
        public Task AddFoodAsync(Food food);
        public void UpdateFood(Food food);
        public void RemoveFood(Food food);
    }
}
