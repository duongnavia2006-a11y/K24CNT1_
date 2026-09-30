using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson12_EF.Models
{
    [Table("Student")]
    public class NtdStudent
    {
        [Key]
        [Display(Name = "Mã sinh viên")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sinh viên tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Họ và tên")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [StringLength(100, ErrorMessage = "Email tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Email")]
        public string StudentEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(50, ErrorMessage = "Số điện thoại tối đa 50 ký tự")]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Số điện thoại")]
        public string StudentPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(150, ErrorMessage = "Địa chỉ tối đa 150 ký tự")]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Địa chỉ")]
        public string StudentAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ảnh đại diện không được để trống")]
        [StringLength(100, ErrorMessage = "Tên file ảnh tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Ảnh đại diện")]
        public string StudentAvatar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime StudentBirthday { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn lớp học")]
        [Display(Name = "Lớp học")]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        [Display(Name = "Lớp học")]
        public virtual NtdStdClass? StdClass { get; set; }

        public virtual ICollection<NtdMark> Marks { get; set; } = new List<NtdMark>();
    }
}
