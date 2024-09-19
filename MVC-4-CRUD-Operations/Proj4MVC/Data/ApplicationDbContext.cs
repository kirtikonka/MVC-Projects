using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proj4MVC.Implementations;
using Proj4MVC.Models;

namespace Proj4MVC.Data
{
    public class ApplicationDbContext : IdentityUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeRepository> Employees { get; set; }
    }
}
