using AutoMapper;
using IranianFoods.Models;
using IranianFoods.Models.ViewModels;

namespace IranianFoods.Utilities
{
    public class FoodMapper:IFoodMapper
    {
        private readonly IMapper _mapper;
        public FoodMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Food GetFoodModelFromViewModel(FoodViewModel foodViewModel)
        {
            Food food = _mapper.Map<FoodViewModel, Food>(foodViewModel);
            return food;
        }

        public async Task<Food> GetFoodModelFromViewModelAsync(FoodViewModel foodViewModel)
        {
            Food food = _mapper.Map<FoodViewModel, Food>(foodViewModel);
            return food;
        }

        public FoodViewModel GetFoodViewModelFromModel(Food foodModel)
        {
            FoodViewModel foodViewModel = _mapper.Map<Food, FoodViewModel>(foodModel);
            return foodViewModel;
        }

        public async Task<FoodViewModel> GetFoodViewModelFromModelAsync(Food foodModel)
        {
            FoodViewModel foodViewModel = _mapper.Map<Food, FoodViewModel>(foodModel);
            return foodViewModel;
        }

        public ICollection<FoodViewModel> GetFoodViewModelsFromModels(ICollection<Food> foodModels)
        {
            ICollection<FoodViewModel> foodViewModels = _mapper.Map<ICollection<Food>, ICollection<FoodViewModel>>(foodModels);
            return foodViewModels;
        }

        public async Task<ICollection<FoodViewModel>> GetFoodViewModelsFromModelsAsync(ICollection<Food> foodModels)
        {
            ICollection<FoodViewModel> foodViewModels = _mapper.Map<ICollection<Food>, ICollection<FoodViewModel>>(foodModels);

            return foodViewModels;
        }
    }
}
