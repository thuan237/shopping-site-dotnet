using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCourse.Data
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string username { get; set; }
        [Required]
        [MaxLength(250)]
        public string password { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }

    }
}
