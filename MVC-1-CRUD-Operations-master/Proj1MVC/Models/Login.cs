using System.ComponentModel.DataAnnotations;

namespace Proj1MVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Field Required")]
        [Display(Name ="Username")]
        //or
        //[Display]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Password")]
        //or
        //[Display]
        public string? Password { get; set; }
    }
}
