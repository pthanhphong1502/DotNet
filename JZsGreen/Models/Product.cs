using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace JZsGreen.Models
{
    public class Product
    {
        [Key]
        public string? Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string? name { get; set; }

        [Display(Name = "Giá Gốc")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Vui Lòng Nhập Giá Gốc")]
        public double? price { get; set; }

        [Range(0,100, ErrorMessage = "Vui lòng nhập trong khoảng 1 -> 100")]
        [Display(Name = "Khuyến mãi")]
        public double? discount { get; set; }

        [Display(Name = "Đơn Vị")]
        [StringLength(10)]
        [Required(ErrorMessage = "Vui Lòng Nhập Đơn Vị")]
        public string? unit { get; set; }

        [Range(1,100,ErrorMessage ="Vui lòng nhập trong khoảng 1 -> 100")]
        [Display(Name ="Số Lượng")]
        [Required(ErrorMessage ="Vui Lòng Nhập Số Lượng")]
        public int? quantity { get; set; }

        [Display(Name = "Giá")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [DataType(DataType.Currency)]
        public double? totalPrice { get; set; }

        [Display(Name = "Tóm tắt")]
        [StringLength(32)]
        public string? summary { get; set; }
        [Display(Name = "Mô tả")]
        public string? description { get; set; }
        [Display(Name = "Còn Hàng")]
        public bool? isActive { get; set; }
        [Display(Name = "Ngày Tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/M/yyyy HH:mm}")]
        public DateTime? dateCreated { get; set; }

        [NotMapped]
        public List<IFormFile>? files { get; set; } = new List<IFormFile>();
        [ForeignKey("Id")]
        public string? categoryId { get; set; }
        public CategoryChild? Category { get; set; }
        public List<ProductImage>? images { get; set; } = new List<ProductImage>();

    }
    public class ProductImage
    {
        [Key]
        public string? id { get; set; }
        public string? fileName { get; set; }

        [ForeignKey("Id")]
        public string? productId { get; set; }
        public Product? Product { get; set; }
    }
}
