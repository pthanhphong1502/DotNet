using System.ComponentModel.DataAnnotations;

namespace JZsGreen.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Vui lòng nhâp email")]
        [EmailAddress(ErrorMessage ="Vui lòng nhập đúng định dạng")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhâp mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu không trùng khớp")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]

        public string? ConfirmPassword { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage ="Nhập nhiều hơn 2 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhâp họ tên")]
        [Display(Name = "Họ tên")]
        public string? FullName { get; set; }


        [Required(ErrorMessage ="Vui lòng nhâp số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Vui lòng nhập 10 số")]
        [MinLength(10,ErrorMessage ="Số điện thoại là 10 số")]
        public string? PhoneNumber { get; set; }
        public bool? AcceptUserAgreement { get; set; }
        public string? RegistrationInValid { get; set; }

    }
}
