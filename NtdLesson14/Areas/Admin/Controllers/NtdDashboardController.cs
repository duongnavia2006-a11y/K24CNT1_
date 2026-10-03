using Microsoft.AspNetCore.Mvc;

namespace NtdLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class NtdDashboardController : Controller
{
    [ActionName("Index")]
    public IActionResult NtdIndex() => View();
}
