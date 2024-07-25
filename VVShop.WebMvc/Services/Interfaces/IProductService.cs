using VVShop.WebMvc.Models;

namespace VVShop.WebMvc.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> FindProductbyId(int id);
        Task<ProductViewModel> CreateProduct(ProductViewModel product);    
        Task<ProductViewModel> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProductById(int id);
    }
}
