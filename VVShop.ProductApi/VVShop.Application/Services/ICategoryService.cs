using VVShop.ProductApi.VVShop.Application.DTOs;

namespace VVShop.ProductApi.VVShop.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoryAll();
        Task<IEnumerable<CategoryDTO>> GetCategoryProducts();
        Task<CategoryDTO> GetCategoryById(int id);
        Task GetCategoryAdd(CategoryDTO categoryDTO);
        Task GetCategoryUpdate(CategoryDTO categoryDTO);
        Task GetCategoryRemove(int id); 
    }
}
