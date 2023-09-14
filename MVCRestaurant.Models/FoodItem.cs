using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Models
{
    public class FoodItem : BaseEntity
    {
        [Required]
        [Key]
        public ulong Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ulong Price { get; set; }

        public string? ImagePath { get; set; }

        [Required]
        public ulong CategoryId { get; set; }
        public FoodCategory Category { get; set; }

        public List<OrderItem> CorrespondingOrders { get; set; }
    }
}
