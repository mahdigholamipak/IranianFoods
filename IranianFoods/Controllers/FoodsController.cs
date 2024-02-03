using IranianFoods.Models;
using IranianFoods.Models.ViewModels;
using IranianFoods.Services;
using IranianFoods.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IranianFoods.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IFoodMapper _foodMapper;
        private readonly ISaveImage _saveImage;

        public FoodsController(IUnitOfWork unitOfWork, ISaveImage saveImage, IFoodMapper foodMapper)
        {
            _unitOfWork = unitOfWork;
            _foodMapper=foodMapper;
            _saveImage = saveImage;
        }

        [HttpGet]
           [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
         [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodViewModel foodViewModel)
        {
          
            if (ModelState.IsValid)
            {
                await _saveImage.UploadFile(foodViewModel.Image);
                    foodViewModel.ImagePath = _saveImage.path;
                    var food = await _foodMapper.GetFoodModelFromViewModelAsync(foodViewModel);
                    await _unitOfWork.Foods.AddFoodAsync(food);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction("Index", "Home");
                
            }


            return View(foodViewModel);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            Food food = await _unitOfWork.Foods.GetFoodAsync(Id);
            FoodViewModel foodViewModel = await _foodMapper.GetFoodViewModelFromModelAsync(food);

            if (food == null)
            {
                return NotFound();
            }

            return View(foodViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(FoodViewModel foodViewModel)
        {
            if (foodViewModel == null)
            {
                return NotFound();
            }
            await _saveImage.UploadFile(foodViewModel.Image);
            foodViewModel.ImagePath = _saveImage.path;
            Food existingFood = await _foodMapper.GetFoodModelFromViewModelAsync(foodViewModel);
            _unitOfWork.Foods.UpdateFood(existingFood);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Remove(int Id)
        {
            Food food = await _unitOfWork.Foods.GetFoodAsync(Id);
            FoodViewModel foodViewModel = await _foodMapper.GetFoodViewModelFromModelAsync(food);

            if (food == null)
            {
                return NotFound();
            }

            return View(foodViewModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(FoodViewModel foodViewModel)
        {
            if (foodViewModel == null)
            {
                return NotFound();
            }
            Food existingFood = await _foodMapper.GetFoodModelFromViewModelAsync(foodViewModel);
            _unitOfWork.Foods.RemoveFood(existingFood);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
