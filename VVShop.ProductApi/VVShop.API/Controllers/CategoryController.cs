using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVShop.ProductApi.VVShop.Application.DTOs;
using VVShop.ProductApi.VVShop.Application.Services;

namespace VVShop.ProductApi.VVShop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategory()
        {
            var categoryDto = await _categoryService.GetCategoryAll();
            if (categoryDto is null)
            {
                return NotFound("categories not found");
            }

            return Ok(categoryDto);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryProducts()
        {
            var categoryDto = await _categoryService.GetCategoryProducts();
            if (categoryDto is null)
            {
                return NotFound("categories not found");
            }

            return Ok(categoryDto);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)
            {
                return NotFound("category not found");
            }

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> GetCategoryPost([FromBody] CategoryDTO categoryDto) //frombody significa que estou passando os dados da categoria que estou incluindo
        {
            if (categoryDto is null)
            {
                return BadRequest("Invalid data");
            }

            await _categoryService.GetCategoryAdd(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto); //Getcategory é para retornar a categoria que foi incluida com o id da categoria getcategory
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> GetCategoryUpdate(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
            {
                return BadRequest();
            }

            if (categoryDto == null)
            {
                return BadRequest();
            }

            await _categoryService.GetCategoryUpdate(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryDelete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)
            {
                return NotFound("category not found");
            }

            await _categoryService.GetCategoryRemove(id);

            return Ok(categoryDto);
        }
    }
}
