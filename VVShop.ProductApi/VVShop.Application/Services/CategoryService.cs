using AutoMapper;
using VVShop.ProductApi.VVShop.Application.DTOs;
using VVShop.ProductApi.VVShop.Core.Models;
using VVShop.ProductApi.VVShop.Infrastucture.Repository;

namespace VVShop.ProductApi.VVShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoryAll()
        {
            var categoryEntity = await _categoryRepository.GetCategoryAll(); //retornando todas as minhas categorias, mas elas são entidades, então uso o auto mapper
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity); // Mapeando a lista de categorias e retornando
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoryProducts()
        {
            // mesmo método acima
            var categoryEntity = await _categoryRepository.GetCategoryProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryId(id); // pego a categoria pelo id
            return _mapper.Map<CategoryDTO>(categoryEntity); //mapeio com o auto mapper
        }

        public async Task GetCategoryAdd(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<CategoryModel>(categoryDTO); //primeiro uso o auto mapper para converter o category.
            await _categoryRepository.GetCategoryCreate(categoryEntity); //acesso o repositorio e inicio o create
            categoryDTO.CategoryId = categoryEntity.CategoryId; //Tenho que atribuir o id da categoria que foi incluido ao id da categoria dto
        }

        public async Task GetCategoryUpdate(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<CategoryModel> (categoryDTO); //Mapeio o dto que estou recebendo para uma entidade
            await _categoryRepository.GetCategoryUpdate(categoryEntity); //depois atualizo a categoria
        }

        public async Task GetCategoryRemove(int id)
        {
            var categoryEntity = _categoryRepository.GetCategoryId(id).Result; //Obter a categoria pelo id 
            await _categoryRepository.GetCategoryDelete(categoryEntity.CategoryId); //depois remover a entidade
        }
    }
}
