using Microsoft.AspNetCore.Mvc;
using NtdLesson08Models.Models;

namespace NtdLesson08Models.Controllers
{
    public class NtdMemberController : Controller
    {
        // Mock data - NtdMember
        private static List<NtdMember> _members = new List<NtdMember>()
        {
            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "tungduong",
                NtdPassword = "241090017",
                NtdFullName = "Nguyen Tung Duong",
                NtdEmail = "tungduong@gmail.com",
                NtdPhone = "0987654321"
            },
            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "tranthib",
                NtdPassword = "SecurePass456#",
                NtdFullName = "Trần Thị B",
                NtdEmail = "tranthib@outlook.com"
            },
            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdUserName = "levanc",
                NtdPassword = "MyPassword789$",
                NtdFullName = "Lê Văn C",
                NtdEmail = "levanc@company.com"
            }
        };

        // GET: Danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult NtdCreate()
        {
            var member = new NtdMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult NtdCreate(NtdMember ntdMember)
        {
            ntdMember.NtdMemberId = Guid.NewGuid().ToString();
            _members.Add(ntdMember);

            return RedirectToAction("Index");
            //return View(ntdMember);
        }

        [HttpGet]
        public IActionResult NtdEdit(string id)
        {
            var member = _members.Where(x => x.NtdMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult NtdEdit(string id, NtdMember ntdMember)
        {
            // var member = _members.Where(x => x.NtdMemberId.Equals(id)).FirstOrDefault();
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].NtdMemberId == id)
                {
                    _members[i].NtdUserName = ntdMember.NtdUserName;
                    _members[i].NtdPassword = ntdMember.NtdPassword;
                    _members[i].NtdFullName = ntdMember.NtdFullName;
                    _members[i].NtdEmail = ntdMember.NtdEmail;

                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult NtdDetails(string id)
        {
            var member = _members.Where(x => x.NtdMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpGet]
        public IActionResult NtdDelete(string id)
        {
            var member = _members.Where(x => x.NtdMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult NtdDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.NtdMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("NtdDelete");
        }
    }
}
