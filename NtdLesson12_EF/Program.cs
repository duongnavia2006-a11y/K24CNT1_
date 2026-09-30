using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình kết nối CSDL SQL Server tới database NETCORE theo slide
var ntdConnectionString = builder.Configuration.GetConnectionString("AppConnection")
    ?? builder.Configuration.GetConnectionString("NtdAppConnection")
    ?? "Server=DUONG;Database=NETCORE;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";

// Tự động kiểm tra tính sẵn sàng của SQL Server Server=DUONG
bool isSqlServerAvailable = false;
try
{
    var testBuilder = new SqlConnectionStringBuilder(ntdConnectionString)
    {
        ConnectTimeout = 1 // Kiểm tra phản hồi trong 1 giây
    };
    using (var testConn = new SqlConnection(testBuilder.ConnectionString))
    {
        testConn.Open();
        isSqlServerAvailable = true;
    }
}
catch
{
    isSqlServerAvailable = false;
}

// Nếu SQL Server DUONG đang chạy -> Dùng SQL Server. Nếu dịch vụ bị tắt -> Dùng SQLite cục bộ NETCORE.db tự động dự phòng
builder.Services.AddDbContext<NtdAppDbContext>(options =>
{
    if (isSqlServerAvailable)
    {
        options.UseSqlServer(ntdConnectionString);
    }
    else
    {
        options.UseSqlite("Data Source=NETCORE.db");
    }
});

var app = builder.Build();

// Khởi tạo và nạp dữ liệu mẫu an toàn khi ứng dụng chạy
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var ntdContext = services.GetRequiredService<NtdAppDbContext>();
        NtdDbInitializer.Initialize(ntdContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogWarning("Khởi tạo dữ liệu: {Message}", ex.Message);
    }
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
