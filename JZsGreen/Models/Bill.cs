using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JZsGreen.Models
{
    public class Bill
    {
        [Key]
        public string? billID { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày lập đơn")]
        [DisplayFormat(DataFormatString = "{0:dd/M/yyyy HH:mm}")]
        public DateTime? date { get; set; }
        [Display(Name = "Thành Tiền")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [DataType(DataType.Currency)]
        public decimal? price { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string? fullName { get; set; }

        [StringLength(150)]
        [Display(Name = "Địa Chỉ")]
        public string? address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số Điện Thoại")]
        public string? phone { get; set; }
        [Display(Name = "Trạng thái")]
        public int? payment { get; set; }

        [Display(Name ="Điểm")]
        public int? point { get; set; }
        [Display(Name = "Khuyến Mãi")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [DataType(DataType.Currency)]
        public decimal? percentDiscount { get; set; }

        [Display(Name = "Tổng Hóa Đơn")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [DataType(DataType.Currency)]
        public decimal? totalPrice { get; set; }
        
        [Display(Name = "Mã khách hàng")]
        [ForeignKey("Id")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public List<DetailOrder>? detailsOrders { get; set; } = new List<DetailOrder>();
    }
    public class DetailOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? odID { get; set; }
        [ForeignKey("billID")]
        public string? billID { get; set; }
        [Display(Name = "Số lượng")]
        public int? quantity { get; set; }
        [ForeignKey("Id")]
        public string? productId { get; set; }
        public Product? product { get; set; } 
    }
 
}
