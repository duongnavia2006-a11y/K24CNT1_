using Microsoft.AspNetCore.Mvc;

namespace NtdLesson13.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ntdAdminTitle = "Bảng điều khiển Quản trị (Admin Dashboard)";
            ViewData["Title"] = ntdAdminTitle;
            return View();
        }
    }
}
