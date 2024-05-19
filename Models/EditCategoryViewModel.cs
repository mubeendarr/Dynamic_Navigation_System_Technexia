using System.ComponentModel.DataAnnotations;

namespace NavigationSystem.Models
{
    public class EditCategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string SubCategory { get; set; }
        [Required]
        public string ClothesTypeCategory { get; set; }
        [Required]
        public string ClothesTypeSubCategory { get; set; }
        [Required]
        public string ColorCategory { get; set; }
    }
}
