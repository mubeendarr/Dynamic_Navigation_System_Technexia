using System.ComponentModel.DataAnnotations;

namespace NavigationSystem.Models
{
    public class AddCategoryViewModel
    {
       
        public string CategoryName { get; set; }
        public string Gender { get; set; }
        public string SubCategory { get; set; }
        public string ClothesTypeCategory { get; set; }
        public string ClothesTypeSubCategory { get; set; }
        public string ColorCategory { get; set; }
    }
}
