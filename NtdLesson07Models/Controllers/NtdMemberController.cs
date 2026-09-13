using Microsoft.AspNetCore.Mvc;
using NtdLesson07Models.Models.DataModels;

namespace NtdLesson07Models.Controllers
{
    public class NtdMemberController : Controller
    {
        //mock data
        protected static List<NtdMember> _members = new List<NtdMember>
        {
            new NtdMember
        {
            NtdMemberId = Guid.NewGuid().ToString(),
            NtdUserName = "tungduong",
            NtdPassword = "password123",
            NtdFullName = "Nguyễn Tùng Dương",
            NtdEmail = "tungduong@gmail.com"
        },
        new NtdMember
        {
            NtdMemberId = Guid.NewGuid().ToString(),
            NtdUserName = "tranthibinh",
            NtdPassword = "123456",
            NtdFullName = "Trần Thị Bình",
            NtdEmail = "tranthibinh@example.com"
        },
        new NtdMember
        {
            NtdMemberId = Guid.NewGuid().ToString(),
            NtdUserName = "levancuong",
            NtdPassword = "123456",
            NtdFullName = "Lê Văn Cường",
            NtdEmail = "levancuong@example.com"
        },
        new NtdMember
        {
            NtdMemberId = Guid.NewGuid().ToString(),
            NtdUserName = "phamthiduyen",
            NtdPassword = "123456",
            NtdFullName = "Phạm Thị Duyên",
            NtdEmail = "phamthiduyen@example.com"
        },
        new NtdMember
        {
            NtdMemberId = Guid.NewGuid().ToString(),
            NtdUserName = "hoangminhduc",
            NtdPassword = "123456",
            NtdFullName = "Hoàng Minh Đức",
            NtdEmail = "hoangminhduc@example.com"
        }
        };
        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "tungduong",
                NtdPassword = "password123",
                NtdFullName = "Nguyễn Tùng Dương",
                NtdEmail = "tungduong@gmail.com"
            };

            //ViewBag.Member = member;
            return View(member);
        }
        //Đưa dữ liệu List ra View
        public IActionResult GetMembers()
        {
            //Lấy từ mock data
            ViewBag.Members = _members;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Create Member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NtdMember member)
        {
            if (ModelState.IsValid)
            {
                member.NtdMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }

            return View(member);
        }
    }
}
