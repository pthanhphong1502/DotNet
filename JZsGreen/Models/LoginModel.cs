using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace JZsGreen.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tài khoản")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nhập không đúng định dạng")]
        [EmailAddress(ErrorMessage = "Nhập không đúng định dạng")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Mật khảu phải dài hơn 6 kí tự")]
        [DataType(DataType.Password)]
        
        public string? Pass { get; set; }

        [Display(Name = "Nhớ lần đăng nhập này?")]
        public bool RememberMe { get; set; }

        public string? LoginInValid { get; set; }
        public string? LoginFailedMessage { get; set; }

    }
}
