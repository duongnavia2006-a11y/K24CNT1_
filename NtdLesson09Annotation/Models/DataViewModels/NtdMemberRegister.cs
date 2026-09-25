using System.ComponentModel.DataAnnotations;

namespace NtdLesson09Annotation.Models.DataViewModels
{
    public class NtdMemberRegister
    {
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