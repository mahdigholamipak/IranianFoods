using IranianFoods.Data;
using IranianFoods.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IranianFoods.Services
{
    public class FoodRepository: Repository<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddFoodAsync(Food food)
        {
            await Context.Set<Food>().AddAsync(food);
        }

        public async Task<ICollection<Food>> FindFoodsAsync(Expression<Func<Food, bool>> predicate)
        {
            return await Context.Set<Food>().Where(predicate).ToListAsync();
        }

        public async Task<ICollection<Food>> GetAllFoodsAsync()
        {
            return await Context.Set<Food>().ToListAsync();
        }

        public async Task<Food> GetFoodAsync(int? Id)
        {
            return await Context.Set<Food>().FirstOrDefaultAsync(food => food.Id == Id);
        }


        void IFoodRepository.AddFood(Food food)
        {
            Context.Set<Food>().Add(food);
        }


        ICollection<Food> IFoodRepository.FindFoods(Expression<Func<Food, bool>> predicate)
        {
            return Context.Set<Food>().Where(predicate).ToList();
        }


        ICollection<Food> IFoodRepository.GetAllFoods()
        {
            return Context.Set<Food>().ToList();
        }

        Food IFoodRepository.GetFood(int? Id)
        {

            return Context.Set<Food>().FirstOrDefault(food => food.Id == Id);

        }

        void IFoodRepository.RemoveFood(Food food)
        {
            Context.Set<Food>().Remove(food);
        }

        void IFoodRepository.UpdateFood(Food food)
        {
            Context.Set<Food>().Update(food);
        }
    }
}
