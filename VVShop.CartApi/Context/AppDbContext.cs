using Microsoft.EntityFrameworkCore;
using VVShop.CartApi.Models;

namespace VVShop.CartApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product>? Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; } 
    public DbSet<CartHeader> CartHeaders { get; set; }

    //Fluent Api

    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Product
        mb.Entity<Product>().HasKey(c => c.Id);

        //Product
        mb.Entity<Product>().Property(c => c.Id).ValueGeneratedNever();

        //Cart Header
        mb.Entity<CartHeader>().Property(c => c.UserId).HasMaxLength(255).IsRequired();

        mb.Entity<CartHeader>().Property(c => c.CouponCode).HasMaxLength(100);
    }
}
