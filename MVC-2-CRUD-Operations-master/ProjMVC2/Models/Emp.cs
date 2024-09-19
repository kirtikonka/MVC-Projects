using System.ComponentModel.DataAnnotations;

namespace ProjMVC2.Models
{
    public class Emp
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double Salary { get; set; }
    }
}
