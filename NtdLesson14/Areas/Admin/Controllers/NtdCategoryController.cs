using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson14.Controllers;
using NtdLesson14.Data;
using NtdLesson14.Models;

namespace NtdLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class NtdCategoryController(NtdStoreDbContext ntdContext) : NtdCrudController<NtdCategory>(ntdContext)
{
    protected override DbSet<NtdCategory> NtdEntities => NtdContext.NtdCategories;
}
