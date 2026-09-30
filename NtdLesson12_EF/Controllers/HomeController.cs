using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public HomeController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: / (Home/Index) - Hiển thị Banner carousel trên trang chủ theo Bài 4 slide Lab 06
        public async Task<IActionResult> Index()
        {
            var ntdBanners = await _ntdContext.Banners
                .Where(b => b.Status == 1)
                .OrderByDescending(b => b.Id)
                .ToListAsync();

            var ntdFeaturedProducts = await _ntdContext.Products
                .Include(p => p.Category)
                .Where(p => p.Status == 1)
                .Take(8)
                .ToListAsync();

            ViewBag.Banners = ntdBanners;
            return View(ntdFeaturedProducts);
        }

        // GET: /Home/Product - Hiển thị dữ liệu sản phẩm dạng cột theo Bài 2 slide Lab 06
        public async Task<IActionResult> Product()
        {
            var ntdProducts = await _ntdContext.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View(ntdProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
