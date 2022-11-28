using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCourse.Data
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string category_name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
