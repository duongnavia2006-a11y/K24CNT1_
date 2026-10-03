using Microsoft.AspNetCore.Mvc;

namespace NtdLesson14.Areas.Admin.ViewComponents;

public class NtdNavLeftViewComponent : ViewComponent
{
    // Invoke is the ASP.NET Core ViewComponent convention method.
    public IViewComponentResult Invoke() => View();
}
