using Microsoft.EntityFrameworkCore;
using VVShop.ProductApi.Models;

namespace VVShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Product { get; set; }

        //Fluent Api

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<CategoryModel>().HasKey(c => c.CategoryId);

            modelBuilder.Entity<CategoryModel>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            //Product

            modelBuilder.Entity<ProductModel>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<ProductModel>().Property(p => p.Description).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<ProductModel>().Property(p => p.ImageUrl).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<ProductModel>().Property(p => p.Price).HasPrecision(12, 2);

            modelBuilder.Entity<CategoryModel>().HasMany(g => g.Products).WithOne(p => p.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel
                {
                    CategoryId = 1,
                    Name = "Material Escolar",
                },
                new CategoryModel
                {
                    CategoryId = 2,
                    Name = "Acessórios",
                }
            );
        }
    }
}
