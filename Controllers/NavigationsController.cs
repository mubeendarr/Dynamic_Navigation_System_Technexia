using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavigationSystem.Data;
using NavigationSystem.Models;

namespace NavigationSystem.Controllers
{
    public class NavigationsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public NavigationsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel viewModel)
        {
            var category = new NavigationCategory
            {
                CategoryName = viewModel.CategoryName,
                Gender = viewModel.Gender,
                SubCategory = viewModel.SubCategory,
                ClothesTypeCategory = viewModel.ClothesTypeCategory,
                ClothesTypeSubCategory = viewModel.ClothesTypeSubCategory,
                ColorCategory = viewModel.ColorCategory
            };
            await dbContext.NavigationCategory.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await dbContext.NavigationCategory.ToListAsync();

            var groupedCategories = categories
                .GroupBy(c => c.CategoryName)
                .ToDictionary(g => g.Key, g => g.ToList());

            return View(groupedCategories);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return NotFound();
            }

            var category = await dbContext.NavigationCategory
                .FirstOrDefaultAsync(c => c.CategoryName == categoryName);

            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new AddCategoryViewModel
            {
                CategoryName = category.CategoryName,
                Gender = category.Gender,
                SubCategory = category.SubCategory,
                ClothesTypeCategory = category.ClothesTypeCategory,
                ClothesTypeSubCategory = category.ClothesTypeSubCategory,
                ColorCategory = category.ColorCategory
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var category = await dbContext.NavigationCategory
                .FirstOrDefaultAsync(c => c.CategoryName == viewModel.CategoryName);

            if (category == null)
            {
                return NotFound();
            }

            category.Gender = viewModel.Gender;
            category.SubCategory = viewModel.SubCategory;
            category.ClothesTypeCategory = viewModel.ClothesTypeCategory;
            category.ClothesTypeSubCategory = viewModel.ClothesTypeSubCategory;
            category.ColorCategory = viewModel.ColorCategory;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        [HttpPost]

        public async Task<IActionResult> Delete(NavigationCategory viewModel) {
            var category = await dbContext.NavigationCategory.FindAsync(viewModel.CategoryName);
                if (category is not null)
            {

                dbContext.NavigationCategory.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(List));

        }



    }
}
