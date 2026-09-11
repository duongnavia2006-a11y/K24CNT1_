using Microsoft.AspNetCore.Mvc;
using NtdLesson06.Models;

namespace NtdLesson06.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? n)
        {
            List<Category> categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Electronics", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "Books", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Clothing", IsActive = true },
                new Category { CategoryId = 4, CategoryName = "Home & Kitchen", IsActive = true }
            };

            n = n ?? 0;
            var search = categories.Where(c => c.CategoryId > n).ToList();
            return View(search);
        }
    }
}