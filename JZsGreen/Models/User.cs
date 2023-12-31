using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace JZsGreen.Models
{
    [Index(nameof(PhoneNumber),IsUnique = true)]
    public class User : IdentityUser
    {
        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string? fullName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/M/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Tạo")]
        public DateTime dateCreated { get; set; }

        [Display(Name = "Điểm Tích Lũy")]
        public int? point { get; set; }

    }
}
