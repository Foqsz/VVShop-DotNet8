using Microsoft.EntityFrameworkCore;
using VVShop.ProductApi.VVShop.Core.Models;
using VVShop.ProductApi.VVShop.Infrastucture.Context;

namespace VVShop.ProductApi.VVShop.Infrastucture.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryAll()
        {
            return await _context.Category.ToListAsync(); //Retornando todos os objetos da memória, não é recomendado em produção com muitos registros.
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryProducts()
        {
            return await _context.Category.Include(c => c.Products).ToListAsync(); //Retornando as categorias e incluindo os produtos
        }

        public async Task<CategoryModel> GetCategoryId(int id)
        {
            return await _context.Category.Where(c => c.CategoryId == id).FirstOrDefaultAsync(); //Retornando uma categoria pelo Id
        }

        public async Task<CategoryModel> GetCategoryCreate(CategoryModel category)
        {
            //Adicioando uma nova categoria
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<CategoryModel> GetCategoryUpdate(CategoryModel category)
        {
            _context.Entry(category).State = EntityState.Modified; //Aqui eu indico que o estado é modificado, então o entity framework entende que houve modificação e executa o salvamento abaixo.
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryModel> GetCategoryDelete(int id)
        {
            //Buscando a categoria que ire deletar
            var category = await GetCategoryId(id);

            //removendo a categoria e salvando
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
