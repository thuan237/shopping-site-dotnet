namespace BasicCourse.Models
{
    public class ProductModel
    {
        public class Product { 
            public string name { get; set; }   
            public double price { get; set; }

        }

        public class ProductVM : Product {
            public Guid product_id { get; set; }    
        }

        public class _ProductModel
        {
            public Guid product_id { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public string category_name { get; set; }

        }
    }

}
