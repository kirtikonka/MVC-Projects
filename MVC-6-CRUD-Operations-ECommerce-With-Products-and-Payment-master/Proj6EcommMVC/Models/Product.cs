using System.ComponentModel.DataAnnotations;

namespace Proj6EcommMVC.Models
{
    public class Product
    {
        [Key]
        public int pid { get; set; }
        public string? Pname { get; set; }
        public string? Pcat { get; set; }
        public string? Picture { get; set; }
        public double Price { get; set; }
    }
}
