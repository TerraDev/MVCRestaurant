using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Models
{
    public class Order
    {
        [Required]
        [Key]
        public string Identifier { get; set; }

        //[Required]
        //public OrderStateEnum OrderState {get; set; }

        public DateTime? OrderDate { get; set; }

        public ulong Total { get; set; }

        public float Tax { get; set; }

        public ulong DeliveryPrice { get; set; }

        public ulong FinalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public ulong? UserId { get; set; }
        public AppUser OrderedBy { get; set; }

        //public string? InvoicePath { get; set; }

        public bool OrderCompleted { get; set; }
    }
}
