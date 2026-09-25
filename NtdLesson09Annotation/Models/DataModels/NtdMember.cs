using System.ComponentModel.DataAnnotations;

namespace NtdLesson09Annotation.Models.DataModels
{
    public class NtdMember
    {
        public string NtdMemberId { get; set; }

        [Required]
        public string NtdUserName { get; set; }

        [Required]
        public string NtdPassword { get; set; }

        [Required]
        public string NtdFullName { get; set; }

        [Required]
        [EmailAddress]
        public string NtdEmail { get; set; }
    }
}