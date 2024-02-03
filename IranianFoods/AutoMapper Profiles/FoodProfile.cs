using AutoMapper;
using IranianFoods.Models;
using IranianFoods.Models.ViewModels;

namespace IranianFoods.AutoMapper_Profiles
{
    public class FoodProfile:Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodViewModel>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath));

            CreateMap<FoodViewModel, Food>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath));

        }
    }
}
