using VVShop.ProductApi.VVShop.Core.Models;

namespace VVShop.ProductApi.VVShop.Infrastucture.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetCategoryAll();
        Task<IEnumerable<CategoryModel>> GetCategoryProducts();
        Task<CategoryModel> GetCategoryId(int id);
        Task<CategoryModel> GetCategoryCreate(CategoryModel category);
        Task<CategoryModel> GetCategoryUpdate(CategoryModel category);
        Task<CategoryModel> GetCategoryDelete(int id);

    }
}
