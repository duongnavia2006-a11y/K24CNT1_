using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson12_EF.Models
{
    [Table("Banner")]
    public class NtdBanner
    {
        [Key]
        [Display(Name = "Mã banner")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(150, ErrorMessage = "Tên banner tối đa 150 ký tự")]
        [Display(Name = "Tên banner")]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; }
    }
}
