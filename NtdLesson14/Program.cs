using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using NtdLesson14.Data;

var ntdBuilder = WebApplication.CreateBuilder(args);

ntdBuilder.Logging.ClearProviders();
ntdBuilder.Logging.AddConsole();
ntdBuilder.Services.AddControllersWithViews();
ntdBuilder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(ntdBuilder.Environment.ContentRootPath, "obj", "DataProtectionKeys")));
ntdBuilder.Services.AddDbContext<NtdStoreDbContext>(ntdOptions =>
    ntdOptions.UseSqlite(ntdBuilder.Configuration.GetConnectionString("NtdStore")
        ?? "Data Source=NtdLesson14.db"));

var ntdApp = ntdBuilder.Build();

using (var ntdScope = ntdApp.Services.CreateScope())
{
    var ntdContext = ntdScope.ServiceProvider.GetRequiredService<NtdStoreDbContext>();
    ntdContext.Database.EnsureCreated();
    NtdDbInitializer.Initialize(ntdContext);
}

if (!ntdApp.Environment.IsDevelopment())
{
    ntdApp.UseExceptionHandler("/NtdHome/Error");
    ntdApp.UseHsts();
}

ntdApp.UseHttpsRedirection();
ntdApp.UseStaticFiles();
ntdApp.UseRouting();
ntdApp.UseAuthorization();

ntdApp.MapControllerRoute(
    name: "admin-category",
    pattern: "Admin/Category/{action=Index}/{id?}",
    defaults: new { area = "Admin", controller = "NtdCategory" });
ntdApp.MapControllerRoute(
    name: "admin-product",
    pattern: "Admin/Product/{action=Index}/{id?}",
    defaults: new { area = "Admin", controller = "NtdProduct" });
ntdApp.MapControllerRoute(
    name: "admin-banner",
    pattern: "Admin/Banner/{action=Index}/{id?}",
    defaults: new { area = "Admin", controller = "NtdBanner" });
ntdApp.MapControllerRoute(
    name: "admin-blog",
    pattern: "Admin/Blog/{action=Index}/{id?}",
    defaults: new { area = "Admin", controller = "NtdBlog" });
ntdApp.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=NtdDashboard}/{action=Index}/{id?}");
ntdApp.MapControllerRoute(
    name: "default",
    pattern: "{controller=NtdHome}/{action=Index}/{id?}");

ntdApp.Run();
