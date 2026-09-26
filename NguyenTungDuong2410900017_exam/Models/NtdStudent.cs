using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenTungDuong2410900017_exam.Models;

public partial class NtdStudent
{
    [Display(Name = "Mã sinh viên")]
    public int Id { get; set; }

    [Display(Name = "Họ và tên")]
    [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
    [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
    public string NtdName { get; set; } = null!;

    [Display(Name = "Giới tính")]
    public bool NtdGender { get; set; }

    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
    public DateOnly? NtdBirthDay { get; set; }

    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    public string? NtdEmail { get; set; }

    [Display(Name = "Số điện thoại")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    public string? NtdPhone { get; set; }

    [Display(Name = "Trạng thái")]
    public bool NtdActive { get; set; }
}
