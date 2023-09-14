using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurant.ViewModels
{
    public class FoodCategoryViewModel
    {
        public ulong id { get; set; }

        [Required(ErrorMessage = "لطفا نام دسته را وارد نمایید.")]
        [DisplayName("نام دسته")]
        public string name { get; set; }

        [DisplayName("آیکون نمایشی")]
        public string? Icon { get; set; }
    }
}
