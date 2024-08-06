using VVShop.WebMvc.Models;

namespace VVShop.WebMvc.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories(string token);  
    }
}
