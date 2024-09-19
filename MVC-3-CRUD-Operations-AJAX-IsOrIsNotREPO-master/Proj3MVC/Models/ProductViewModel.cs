using System.ComponentModel.DataAnnotations;

namespace Proj3MVC.Models
{
    public class ProductViewModel
    {
        [Key]
        public int pid { get; set; }
        public string? Pname { get; set; }
        public string? Pcat { get; set; }
        public IFormFile? Picture { get; set; }
        public double Price { get; set; }
    }
}
