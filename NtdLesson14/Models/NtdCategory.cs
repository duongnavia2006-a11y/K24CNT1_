using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson14.Models;

[Table("Category")]
public class NtdCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int NtdId { get; set; }

    [Required(ErrorMessage = "Tên danh mục không được để trống.")]
    [StringLength(100)]
    [Display(Name = "Tên danh mục")]
    [Column("Name")]
    public string NtdName { get; set; } = string.Empty;

    [Range(0, 255)]
    [Display(Name = "Trạng thái")]
    [Column("Status")]
    public byte NtdStatus { get; set; } = 1;

    [DataType(DataType.Date)]
    [Display(Name = "Ngày tạo")]
    [Column("CreatedDate")]
    public DateTime NtdCreatedDate { get; set; } = DateTime.Today;

    [StringLength(100)]
    [Display(Name = "Ảnh")]
    [Column("Image")]
    public string? NtdImage { get; set; }

    [StringLength(350)]
    [Display(Name = "Mô tả")]
    [Column("Description")]
    public string? NtdDescription { get; set; }
}
