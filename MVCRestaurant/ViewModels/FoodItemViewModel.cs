using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurant.ViewModels
{
    public class FoodItemViewModel
    {
        public ulong id { get; set; }

        [Required(ErrorMessage = "لطفا نام غذا را وارد نمایید.")]
        [DisplayName("نام غذا")]
        public string name { get; set; }

        [Required(ErrorMessage = "لطفا قیمت غذا را وارد نمایید.")]
        [DisplayName("قیمت")]
        public ulong price { get; set; }

        public string ImagePath { get; set; }

        public FoodCategoryViewModel category { get; set; }
    }
}
