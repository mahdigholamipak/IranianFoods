using IranianFoods.Models;
using IranianFoods.Services;
using IranianFoods.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IranianFoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFoodMapper _foodMapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IFoodMapper foodMapper)
        {
            _unitOfWork = unitOfWork;
            _foodMapper=foodMapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var foods =await _unitOfWork.Foods.GetAllFoodsAsync();
            var foodsViewModel =await _foodMapper.GetFoodViewModelsFromModelsAsync(foods);
            
            return View(foodsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
