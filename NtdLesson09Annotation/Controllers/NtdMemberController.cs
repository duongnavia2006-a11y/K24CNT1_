using Microsoft.AspNetCore.Mvc;
using NtdLesson09Annotation.Models.DataModels;
using NtdLesson09Annotation.Models.DataViewModels;

namespace NtdLesson09Annotation.Controllers
{
    public class NtdMemberController : Controller
    {
        protected List<NtdMember> _members = new List<NtdMember>
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
                NtdUserName = "nguyenvana",
                NtdPassword = "123456",
                NtdFullName = "Nguyễn Văn A",
                NtdEmail = "nguyenvana@gmail.com"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "tranthibinh",
                NtdPassword = "123456",
                NtdFullName = "Trần Thị Bình",
                NtdEmail = "tranthibinh@gmail.com"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "levancuong",
                NtdPassword = "123456",
                NtdFullName = "Lê Văn Cường",
                NtdEmail = "levancuong@gmail.com"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "phamthiduyen",
                NtdPassword = "123456",
                NtdFullName = "Phạm Thị Duyên",
                NtdEmail = "phamthiduyen@gmail.com"
            }
        };

        public IActionResult Index()
        {
            ViewBag.Members = _members;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NtdMemberRegister memberRegister)
        {
            if (ModelState.IsValid)
            {
                var member = new NtdMember
                {
                    NtdMemberId = Guid.NewGuid().ToString(),
                    NtdUserName = memberRegister.NtdUserName,
                    NtdPassword = memberRegister.NtdPassword,
                    NtdFullName = memberRegister.NtdFullName,
                    NtdEmail = memberRegister.NtdEmail
                };

                _members.Add(member);

                return RedirectToAction("Index");
            }

            return View(memberRegister);
        }
    }
}