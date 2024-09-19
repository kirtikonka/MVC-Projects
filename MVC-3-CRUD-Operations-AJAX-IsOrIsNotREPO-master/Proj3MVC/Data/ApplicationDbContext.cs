using Microsoft.EntityFrameworkCore;
using Proj3MVC.Models;

namespace Proj3MVC.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
        public DbSet<Emp> Emps { get; set; }
        public DbSet<Product> Products { get; set; }    

    }
}
