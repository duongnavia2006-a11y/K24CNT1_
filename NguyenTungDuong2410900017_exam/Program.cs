using Microsoft.EntityFrameworkCore;
using NguyenTungDuong2410900017_exam.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with ConnectionString
builder.Services.AddDbContext<NguyenTungDuong2410900017DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NguyenTungDuong2410900017Db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
