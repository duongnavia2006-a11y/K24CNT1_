using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson14.Controllers;
using NtdLesson14.Data;
using NtdLesson14.Models;

namespace NtdLesson14.Areas.Admin.Controllers;

[Area("Admin")]
public class NtdBlogController(NtdStoreDbContext ntdContext) : NtdCrudController<NtdBlog>(ntdContext)
{
    protected override DbSet<NtdBlog> NtdEntities => NtdContext.NtdBlogs;
}
