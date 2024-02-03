using System.ComponentModel.DataAnnotations;

namespace IranianFoods.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ImagePath { get; set; }
    }
}
