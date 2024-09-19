using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proj1MVC.Models
{
    public class Emp
    {
        [Required(ErrorMessage ="Field Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [StringLength(10,ErrorMessage ="Only 10 characters are allowed")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [Range(minimum:1000, maximum:1000000,ErrorMessage ="Salary range is 1000-1000000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Field Required")]
        //for Indian Number
        [RegularExpression(@"^(0|91)?[6-9][0-9]{9}$", ErrorMessage = "Invalid Mobile Number.")]
        //[Phone(ErrorMessage ="Invalid Contact Number")]
        //[Range(minimum: 10, maximum: 10, ErrorMessage = "Invalid Contact Number")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        public string? PanCard { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [Url]
        public string? Url { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [CreditCard]
        //[Range(100000000000, 9999999999999999999, ErrorMessage = "Credit Card number must be between 12 and 19 digits")]
        public string? Credit {  get; set; }    

        //[Required(ErrorMessage = "Field Required")]
        //[StringLength(60)]
        //[RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "Not a valid website URL")]
        //public string? Website { get; set; }

        //[Required(ErrorMessage = "Field Required")]
        //[StringLength(200)]
        //[RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "Not a valid YouTube video")]
        //public string? YouTubeVideo { get; set; }

    }
}
