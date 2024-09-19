using Microsoft.EntityFrameworkCore;
using ProjMVC2.Models;

namespace ProjMVC2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Emp> emps { get; set; }
    }
}
