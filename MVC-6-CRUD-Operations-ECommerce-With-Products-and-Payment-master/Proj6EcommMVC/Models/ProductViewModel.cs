using System.ComponentModel.DataAnnotations;

namespace Proj6EcommMVC.Models
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
