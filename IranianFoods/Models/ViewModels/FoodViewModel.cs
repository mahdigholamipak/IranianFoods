using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace IranianFoods.Models.ViewModels
{
    public class FoodViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
    }
}