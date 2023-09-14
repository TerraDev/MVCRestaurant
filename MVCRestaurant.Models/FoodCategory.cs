using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Models
{
    public class FoodCategory : BaseEntity
    {
        [Required]
        [Key]
        public ulong Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Icon { get; set; }

        public List<FoodItem> FoodItems { get; set; }
    }
}
