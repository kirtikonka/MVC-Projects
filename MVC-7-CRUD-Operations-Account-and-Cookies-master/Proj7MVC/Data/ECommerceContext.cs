using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Proj7MVC.Models;

namespace Proj7MVC.Data;

public partial class ECommerceContext : DbContext
{
    public ECommerceContext()
    {
    }

    public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
    {
    }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public DbSet<TestTwo> TestTwos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;Encrypt=True");
    //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth__3213E83F1D50A7D9");

            entity.ToTable("Auth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Urole)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("urole");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Carts__DD37D91AAF3DD24F");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Dt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dt");
            entity.Property(e => e.Pcat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pcat");
            entity.Property(e => e.Pic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pic");
            entity.Property(e => e.Pname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pname");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Qyt).HasColumnName("qyt");
            entity.Property(e => e.Suser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("suser");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B2AE9CB2949");

            entity.Property(e => e.CartItemId).HasColumnName("CartItemID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__CartItems__Produ__38996AB5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDD595C983");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACD269649F");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsBlocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.Pass).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
