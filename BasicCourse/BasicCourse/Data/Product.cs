using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCourse.Data
{
    [Table("product")]
    public class Product
    {
        [Key]
        public Guid product_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        public string desc { get; set; }
        [Range(0, double.MaxValue)]
        public double price { get; set; }
        public byte discount { get; set; }

        // ? -> có thể có hoặc không
        public int? category_id { get; set; }
        [ForeignKey("category_id")]
        public Category? category { get; set; }
    }
}
