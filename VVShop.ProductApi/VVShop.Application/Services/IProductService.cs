using VVShop.ProductApi.VVShop.Application.DTOs;

namespace VVShop.ProductApi.VVShop.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAll();
        Task<ProductDTO> GetProductById(int id);
        Task GetProductAdd(ProductDTO productDTO);
        Task GetProductUpdate(ProductDTO productDTO);
        Task GetProductRemove(int id);
    }
}
