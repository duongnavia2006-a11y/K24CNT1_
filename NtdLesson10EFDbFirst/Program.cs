using Microsoft.EntityFrameworkCore;
using NtdLesson10EFDbFirst.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NtdK24cntt2lesson10EFdbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NtdK24cntt2lesson10EFDbFirst")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NtdK24cntt2lesson10EFdbContext>();
    db.Database.EnsureCreated();

    if (!db.NtdMembers.Any())
    {
        db.NtdMembers.AddRange(
            new NtdMember { NtdUserName = "tungduong", NtdPassword = "password123", NtdFullName = "Nguyen Tung Duong", NtdEmail = "tungduong@gmail.com", NtdPhone = "0123456789", NtdStatus = true },
            new NtdMember { NtdUserName = "nguyenvana", NtdPassword = "123456", NtdFullName = "Nguyen Van A", NtdEmail = "nguyenvana@gmail.com", NtdPhone = "0123456788", NtdStatus = true },
            new NtdMember { NtdUserName = "tranthibinh", NtdPassword = "123456", NtdFullName = "Tran Thi Binh", NtdEmail = "tranthibinh@gmail.com", NtdPhone = "0123456787", NtdStatus = true }
        );
        db.SaveChanges();
    }
}

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
    pattern: "{controller=NtdMembers}/{action=Index}/{id?}");

app.Run();
