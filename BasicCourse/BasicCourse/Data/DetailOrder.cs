namespace BasicCourse.Data
{
    public class DetailOrder
    {
        public Guid product_id { get; set; }
        public Guid order_id { get; set; }
        public int quantity { get; set; }
        public double total_money { get; set; }

        //relationship
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
