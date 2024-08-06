using VVShop.WebMvc.Models;

namespace VVShop.WebMvc.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts(string token);
        Task<ProductViewModel> FindProductbyId(int id, string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel product, string token);    
        Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token);
        Task<bool> DeleteProductById(int id, string token);
    }
}
