using Microsoft.AspNetCore.Mvc;
using NtdLesson4Lab.Models;

namespace NtdLesson4Lab.Controllers
{
    public class NtdAccountController : Controller
    {
        private readonly List<NtdAccount> ntdAccounts = new()
        {
            new NtdAccount
            {
                Id = 1,
                Name = "Nguyễn Tùng Lâm",
                Email = "tunglam@example.com",
                Phone = "0912345678",
                Avatar = "/images/3.jng",
                Address = "Hà Nội",
                Bio = "Sinh viên Công nghệ thông tin, yêu thích lập trình và công nghệ.",
                Gender = 0,
                Birthday = new DateTime(2006, 5, 15)
            },

            new NtdAccount
            {
                Id = 2,
                Name = "Trần Minh Anh",
                Email = "minhanh@example.com",
                Phone = "0923456789",
                Avatar = "/images/4.jng",
                Address = "Hải Phòng",
                Bio = "Yêu thích thiết kế giao diện và phát triển website.",
                Gender = 1,
                Birthday = new DateTime(2006, 8, 20)
            },

            new NtdAccount
            {
                Id = 3,
                Name = "Lê Hoàng Nam",
                Email = "hoangnam@example.com",
                Phone = "0934567890",
                Avatar = "/images/1.jng",
                Address = "Đà Nẵng",
                Bio = "Đam mê lập trình C#, ASP.NET Core và phát triển phần mềm.",
                Gender = 0,
                Birthday = new DateTime(2005, 11, 30)
            },

            new NtdAccount
            {
                Id = 4,
                Name = "Phạm Minh Châu",
                Email = "minhchau@example.com",
                Phone = "0945678901",
                Avatar = "/images/2.jng",
                Address = "Cần Thơ",
                Bio = "Quan tâm đến khởi nghiệp, công nghệ và kinh doanh.",
                Gender = 1,
                Birthday = new DateTime(2006, 3, 10)
            },

            new NtdAccount
            {
                Id = 5,
                Name = "Hoàng Quốc Dũng",
                Email = "quocdung@example.com",
                Phone = "0956789012",
                Avatar = "/images/3.jng",
                Address = "TP. Hồ Chí Minh",
                Bio = "Yêu thích lập trình web, cơ sở dữ liệu và công nghệ mới.",
                Gender = 0,
                Birthday = new DateTime(2005, 7, 25)
            }
        };
        public IActionResult NtdIndex()
        {
            ViewBag.NtdAccounts = ntdAccounts;
            return View();
        }
    }
}
