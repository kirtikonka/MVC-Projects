namespace Proj4MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ApplicationUser>? Employees { get; set; }
    }
}
