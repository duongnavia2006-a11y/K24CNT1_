using System.ComponentModel;

namespace NtdLesson08Models.Models
{
    public class NtdMember
    {
        public string NtdMemberId { get; set; }
        public string NtdUserName { get; set; }
        public string NtdPassword { get; set; }

        [DisplayName("Họ và tên")]
        public string NtdFullName { get; set; }
        public string NtdEmail { get; set; }
        public string NtdPhone { get; set; }
    }

}
