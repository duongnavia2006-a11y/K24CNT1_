using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NtdLesson14.Models;

namespace NtdLesson14.Controllers;

public class NtdHomeController : Controller
{
    [ActionName("Index")]
    public IActionResult NtdIndex() => View();

    [ActionName("About")]
    public IActionResult NtdAbout() => View();

    [ActionName("Contact")]
    public IActionResult NtdContact() => View();

    [ActionName("Privacy")]
    public IActionResult NtdPrivacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [ActionName("Error")]
    public IActionResult NtdError() => View(new NtdErrorViewModel
    {
        NtdRequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
}
