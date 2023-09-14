using MVCRestaurant.Models;
using MVCRestaurant.ViewModels;

namespace MVCRestaurant.Mapper
{
    public static class OrderMapper
    {
        public static OrderViewModel OrderToVM(Order order)
        {

            List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();
            if (order.OrderItems != null)
            {
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    orderItems.Add(new OrderItemViewModel()
                    {
                        quantity = orderItem.quantity,
                        food = new FoodItemViewModel()
                        {
                        id = orderItem.OrderedFood.Id,
                        name = orderItem.OrderedFood.Name,
                        price = orderItem.OrderedFood.Price,
                        ImagePath = orderItem.OrderedFood.ImagePath,
                        category = null
                        }
                    });
                }
            }
            return new OrderViewModel()
            {
                Identifier = order.Identifier,
                Tax = order.Tax,
                DeliveryPrice = order.DeliveryPrice,
                Total = order.Total,
                FinalPrice = order.FinalPrice,
                orderDate = order.OrderDate,
                //InvoicePath = order.InvoicePath,
                orderCompleted = order.OrderCompleted,
                orderItems = orderItems
            };
        }
    }
}
