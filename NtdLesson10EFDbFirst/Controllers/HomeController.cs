using Microsoft.AspNetCore.Mvc;

namespace NtdLesson10EFDbFirst.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Privacy() => View();
}
