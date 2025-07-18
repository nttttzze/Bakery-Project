using mormorsBageri.Entities;
using Microsoft.EntityFrameworkCore;
using mormorsBageri.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace mormorsBageri;

public class DataContext : IdentityDbContext<User>
{
    public DbSet<Product> Products { get; set;}
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SupplierProduct> SupplierProducts { get; set; }


     public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SupplierProduct>().HasKey(sp => new { sp.SupplierId, sp.ProductId });

        modelBuilder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Product)
            .WithMany(p => p.SupplierProducts)
            .HasForeignKey(sp => sp.ProductId);

        modelBuilder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Supplier)
            .WithMany(s => s.SupplierProducts)
            .HasForeignKey(sp => sp.SupplierId);
    }
}
