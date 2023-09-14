using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCRestaurant.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        [DisplayName("نام کاربری")]
        public string userName { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد نمایید")]
        [StringLength(12, ErrorMessage = "تعداد کاراکترها باید بین {2} و {1} باشد", MinimumLength = 5)]
        [DisplayName("رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
