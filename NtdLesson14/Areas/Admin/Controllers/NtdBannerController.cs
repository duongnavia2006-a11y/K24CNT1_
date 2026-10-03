using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson14.Controllers;
using NtdLesson14.Data;
using NtdLesson14.Models;

namespace NtdLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class NtdBannerController(NtdStoreDbContext ntdContext) : NtdCrudController<NtdBanner>(ntdContext)
{
    protected override DbSet<NtdBanner> NtdEntities => NtdContext.NtdBanners;
}
