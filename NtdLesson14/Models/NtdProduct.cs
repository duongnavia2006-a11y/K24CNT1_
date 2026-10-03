using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NtdLesson14.Models;

[Table("Product")]
public class NtdProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int NtdId { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
    [StringLength(100)]
    [Display(Name = "Tên sản phẩm")]
    [Column("Name")]
    public string NtdName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Giá bán không được để trống.")]
    [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "Giá bán phải lớn hơn 0.")]
    [Display(Name = "Giá bán")]
    [Column("Price", TypeName = "decimal(18,2)")]
    public decimal NtdPrice { get; set; }

    [Range(typeof(decimal), "0", "999999999")]
    [Display(Name = "Giá khuyến mãi")]
    [Column("salePrice", TypeName = "decimal(18,2)")]
    public decimal NtdSalePrice { get; set; }

    [Range(0, 255)]
    [Display(Name = "Trạng thái")]
    [Column("Status")]
    public byte NtdStatus { get; set; } = 1;

    [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
    [Display(Name = "Danh mục")]
    [Column("CategoryId")]
    public int NtdCategoryId { get; set; }

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

    public NtdCategory? NtdCategory { get; set; }
}
