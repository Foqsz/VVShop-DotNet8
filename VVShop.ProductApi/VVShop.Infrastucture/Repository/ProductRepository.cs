using Microsoft.EntityFrameworkCore;
using VVShop.ProductApi.VVShop.Core.Models;
using VVShop.ProductApi.VVShop.Infrastucture.Context;

namespace VVShop.ProductApi.VVShop.Infrastucture.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetProductAll()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductModel> GetProductCreate(ProductModel product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();  
            return product;
        } 

        public async Task<ProductModel> GetProductUpdate(ProductModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ProductModel> GetProductDelete(int id)
        {
            var product = await GetProductById(id);
            _context.Remove(product);   
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
