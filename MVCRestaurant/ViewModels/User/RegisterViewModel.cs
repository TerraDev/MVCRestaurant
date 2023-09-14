using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCRestaurant.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید")]
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد نمایید")]
        [StringLength(12, ErrorMessage = "تعداد کاراکترهای رمز عبور باید بین {2} و {1} باشد", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری را تکرار نمایید")]
        [StringLength(12, ErrorMessage = "تعداد کاراکترهای رمز عبور باید بین {2} و {1} باشد", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار آن باید یکسان باشند.")]
        [DisplayName("تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
}
