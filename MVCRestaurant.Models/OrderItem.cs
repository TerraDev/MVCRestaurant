using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Models
{
    public class OrderItem
    {
        [Key]
        public ulong Id { get; set; }

        [Required]
        public uint quantity { get; set; }

        [Required]
        public ulong OrderedFoodId { get; set; }
        public FoodItem OrderedFood { get; set; }

        [Required]
        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
