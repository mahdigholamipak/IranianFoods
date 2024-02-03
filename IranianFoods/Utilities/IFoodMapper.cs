using IranianFoods.Models;
using IranianFoods.Models.ViewModels;

namespace IranianFoods.Utilities
{
    public interface IFoodMapper
    {
        public Food GetFoodModelFromViewModel(FoodViewModel foodViewModel);

        public Task<Food> GetFoodModelFromViewModelAsync(FoodViewModel foodViewModel);

        public FoodViewModel GetFoodViewModelFromModel(Food foodModel);
        public Task<FoodViewModel> GetFoodViewModelFromModelAsync(Food foodModel);

        public ICollection<FoodViewModel> GetFoodViewModelsFromModels(ICollection<Food> foodModels);
        public Task<ICollection<FoodViewModel>> GetFoodViewModelsFromModelsAsync(ICollection<Food> foodModels);
    }
}
