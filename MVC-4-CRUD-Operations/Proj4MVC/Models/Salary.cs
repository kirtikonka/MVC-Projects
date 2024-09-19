namespace Proj4MVC.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal NetSalary { get; set; }

    }
}
