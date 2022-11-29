namespace BasicCourse.Data
{
    public class Order
    {
        public enum order_status
        {
            New = 0,
            Payment = 1,
            Complete = 2,
            Cancel = -1
        }

        public Guid order_id { get; set; }    
        public DateTime order_date { get; set;}
        public DateTime? delivery_date { get; set;}
        public order_status status { get; set;}
        public string receiver { get; set;}
        public string delivery_address { get; set;}
        public string phone_number { get; set;}

        public ICollection<DetailOrder> detailOrders { get; set;}
        public Order()
        {
            detailOrders = new List<DetailOrder>();
        }
    }
}
