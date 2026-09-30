using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson12_EF.Models
{
    [Table("Marks")]
    public class NtdMark
    {
        [Display(Name = "Môn học")]
        public int SubjectId { get; set; }

        [Display(Name = "Sinh viên")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Điểm số không được để trống")]
        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        [Display(Name = "Điểm số")]
        public float Score { get; set; }

        [ForeignKey("SubjectId")]
        [Display(Name = "Môn học")]
        public virtual NtdSubject? Subject { get; set; }

        [ForeignKey("StudentId")]
        [Display(Name = "Sinh viên")]
        public virtual NtdStudent? Student { get; set; }
    }
}
