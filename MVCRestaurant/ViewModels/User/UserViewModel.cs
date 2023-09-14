using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurant.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel(ulong? id)
        {
            this.userId = id;
        }

        public UserViewModel()
        {
        }

        public ulong? userId { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        [DisplayName("نام کاربری")]
        public string userName { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل را وارد نمایید")]
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا نقش کاربر را انتخاب نمایید.")]
        [DisplayName("نقش")]
        public string? Role { get; set; }

        [DisplayName("رمز عبور")]
        public bool? PasswordSet { get; set; }
    }
}
