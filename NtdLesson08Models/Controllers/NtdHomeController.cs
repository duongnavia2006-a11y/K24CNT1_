using Microsoft.AspNetCore.Mvc;
using NtdLesson08Models.Models;
using System.Diagnostics;

namespace NtdLesson08Models.Controllers
{
    public class NtdHomeController : Controller
    {
        public IActionResult NtdIndex()
        {
            return View("~/Views/NtdHome/NtdIndex.cshtml");
        }

        // Privacy
        public IActionResult NtdPrivacy()
        {
            return View("~/Views/NtdHome/NtdPrivacy.cshtml");
        }

        public IActionResult NtdAbout()
        {
            return View("~/Views/NtdHome/NtdAbout.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
