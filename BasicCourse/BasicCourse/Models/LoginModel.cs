using System.ComponentModel.DataAnnotations;

namespace BasicCourse.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(100)]
        public string username { get; set; }
        [Required]
        [MaxLength(250)]
        public string password { get; set; }
    }
}
