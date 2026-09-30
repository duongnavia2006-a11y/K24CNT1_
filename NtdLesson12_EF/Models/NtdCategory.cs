using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson12_EF.Models
{
    [Table("Category")]
    public class NtdCategory
    {
        [Key]
        [Display(Name = "Mã danh mục")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không vượt quá 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "tinyint")]
        [Display(Name = "Trạng thái")]
        public byte Status { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        // Danh sách sản phẩm theo danh mục
        public virtual ICollection<NtdProduct> Products { get; set; } = new List<NtdProduct>();
    }
}
