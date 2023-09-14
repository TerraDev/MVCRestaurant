using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCRestaurant.ViewModels.User
{
    public class PasswordViewModel
    {
        [Required]
        public ulong userId { get; set; }

        [Required(ErrorMessage ="لطفا رمز عبور را وارد نمایید")]
        [StringLength(12, ErrorMessage = "تعداد کاراکترها باید بین {2} و {1} باشد.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را تکرار نمایید")]
        [StringLength(12, ErrorMessage = "تعداد کاراکترها باید بین {2} و {1} باشد.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="رمز عبور و تکرار آن باید یکسان باشند.")]
        [DisplayName("تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
}
