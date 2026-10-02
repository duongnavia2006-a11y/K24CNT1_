using Microsoft.AspNetCore.Mvc;

namespace NtdLesson13.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class NtdHomeController : Controller
    {
        // GET: /Admins/Home/Index hoặc /Admins
        public IActionResult Index()
        {
            var ntdAdminTitle = "Bảng điều khiển Quản trị (Admin Dashboard)";
            ViewData["Title"] = ntdAdminTitle;
            return View();
        }
    }
}
