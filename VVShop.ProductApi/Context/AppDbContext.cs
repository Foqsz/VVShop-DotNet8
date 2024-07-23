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
    }
}
