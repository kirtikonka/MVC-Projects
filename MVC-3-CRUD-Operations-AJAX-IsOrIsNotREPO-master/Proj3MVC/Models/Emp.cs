using System.ComponentModel.DataAnnotations;

namespace Proj3MVC.Models
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter your Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter your Department")]
        public string? Dept { get; set; }

        [Required(ErrorMessage = "Enter your Salary")]
        public string? Salary { get; set; }
    }
}
