namespace BasicCourse.Models
{
    public class ProductVM
    {
        public string name { get; set; }
        public string price { get; set; }
    }

    public class Product : ProductVM
    {
        public Guid product_id {get; set;}
    }
}

