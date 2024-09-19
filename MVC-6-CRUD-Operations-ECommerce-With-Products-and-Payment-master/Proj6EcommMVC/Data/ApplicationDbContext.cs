using Microsoft.EntityFrameworkCore;
using Proj6EcommMVC.Models;

namespace Proj6EcommMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
