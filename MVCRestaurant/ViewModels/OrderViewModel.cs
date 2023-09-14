namespace MVCRestaurant.ViewModels
{
    public class OrderViewModel
    {
        public string Identifier { get; set; }

        //public string InvoicePath { get; set; }

        public List<OrderItemViewModel> orderItems { get; set; }

        public ulong Total { get; set; }

        public float Tax { get; set; }

        public ulong DeliveryPrice { get; set; }

        public ulong FinalPrice { get; set; }

        public bool orderCompleted { get; set; }

        public DateTime? orderDate { get; set; }
    }
}
