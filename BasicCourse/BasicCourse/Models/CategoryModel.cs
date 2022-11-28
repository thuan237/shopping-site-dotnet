using System.ComponentModel.DataAnnotations;

namespace BasicCourse.Models
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(100)]
        public string category_name { get; set; }
    }
}
