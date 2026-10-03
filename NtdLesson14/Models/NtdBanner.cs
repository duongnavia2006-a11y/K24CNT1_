using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson14.Models;

[Table("Banner")]
public class NtdBanner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int NtdId { get; set; }

    [Required(ErrorMessage = "Tên banner không được để trống.")]
    [StringLength(100)]
    [Display(Name = "Tên banner")]
    [Column("Name")]
    public string NtdName { get; set; } = string.Empty;

    [Range(0, 255)]
    [Display(Name = "Trạng thái")]
    [Column("Status")]
    public byte NtdStatus { get; set; } = 1;

    [Display(Name = "Thứ tự")]
    [Column("Prioty")]
    public int NtdPrioty { get; set; }

    [StringLength(100)]
    [Display(Name = "Ảnh")]
    [Column("Image")]
    public string? NtdImage { get; set; }

    [StringLength(350)]
    [Display(Name = "Mô tả")]
    [Column("Description")]
    public string? NtdDescription { get; set; }
}
