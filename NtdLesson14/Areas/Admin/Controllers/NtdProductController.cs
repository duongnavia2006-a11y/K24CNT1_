using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NtdLesson14.Controllers;
using NtdLesson14.Data;
using NtdLesson14.Models;

namespace NtdLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class NtdProductController(NtdStoreDbContext ntdContext) : NtdCrudController<NtdProduct>(ntdContext)
{
    protected override DbSet<NtdProduct> NtdEntities => NtdContext.NtdProducts;

    public override void OnActionExecuting(ActionExecutingContext ntdContext)
    {
        ViewBag.NtdCategoryOptions = new SelectList(
            NtdContext.NtdCategories.AsNoTracking().OrderBy(ntdCategory => ntdCategory.NtdName).ToList(),
            nameof(NtdCategory.NtdId),
            nameof(NtdCategory.NtdName));
        base.OnActionExecuting(ntdContext);
    }
}
