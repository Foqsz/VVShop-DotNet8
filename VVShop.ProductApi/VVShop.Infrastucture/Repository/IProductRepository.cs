using VVShop.ProductApi.VVShop.Core.Models;

namespace VVShop.ProductApi.VVShop.Infrastucture.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProductAll();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> GetProductCreate(ProductModel model);    
        Task<ProductModel> GetProductUpdate(ProductModel model);
        Task<ProductModel> GetProductDelete(int id);
    }
}
