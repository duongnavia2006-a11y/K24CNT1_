var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// 1. Cấu hình Route cho Area (Admins) - Theo Slide 22
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// 2. Cấu hình Route cho Products tương thích hoàn toàn Slide 8-12
app.MapControllerRoute(
    name: "products_alias",
    pattern: "Products/{action=Index}/{id?}",
    defaults: new { controller = "NtdProducts" });

// 3. Cấu hình Route cho Product/About (Link trong Slide 8: href="/Product/About")
app.MapControllerRoute(
    name: "product_single_alias",
    pattern: "Product/{action=About}/{id?}",
    defaults: new { controller = "NtdProducts" });

// 4. Route mặc định của ứng dụng
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
