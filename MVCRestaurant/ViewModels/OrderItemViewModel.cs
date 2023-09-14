using Humanizer;

namespace MVCRestaurant.ViewModels
{
    public class OrderItemViewModel
    {
        public FoodItemViewModel food { get; set; }
        public uint quantity { get; set; }
    }
}
