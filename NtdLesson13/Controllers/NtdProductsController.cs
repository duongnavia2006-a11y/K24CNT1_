using Microsoft.AspNetCore.Mvc;

namespace NtdLesson13.Controllers
{
    /// <summary>
    /// Controller quản lý Sản phẩm theo Slide bài giảng Session 07 - Tìm hiểu về Layout
    /// Tuân thủ quy ước đặt tên: Tiền tố Hvt (Ntd - Nguyễn Tùng Dương)
    /// </summary>
    public class NtdProductsController : Controller
    {
        // Khai báo hằng số theo quy ước tiền tố Hvt (Ntd)
        public const string NtdProjectAuthor = "Nguyễn Tùng Dương";
        public const string NtdLessonCode = "NtdLesson13";

        // GET: /Products/Index hoặc /NtdProducts/Index
        public IActionResult Index()
        {
            var ntdPageTitle = "Index";
            ViewData["Title"] = ntdPageTitle;
            return View();
        }

        // GET: /Products/Search hoặc /NtdProducts/Search
        public IActionResult Search()
        {
            var ntdPageTitle = "Search";
            ViewData["Title"] = ntdPageTitle;
            return View();
        }

        // GET: /Products/Hots hoặc /NtdProducts/Hots
        public IActionResult Hots()
        {
            var ntdPageTitle = "Hots";
            ViewData["Title"] = ntdPageTitle;
            return View();
        }

        // GET: /Products/About hoặc /Product/About hoặc /NtdProducts/About
        public IActionResult About()
        {
            var ntdPageTitle = "About";
            ViewData["Title"] = ntdPageTitle;
            return View();
        }
    }
}
