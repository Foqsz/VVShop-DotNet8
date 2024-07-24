using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVShop.ProductApi.VVShop.Application.DTOs;
using VVShop.ProductApi.VVShop.Application.Services;

namespace VVShop.ProductApi.VVShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()
        {
            var productDto = await _productService.GetProductsAll();
            if (productDto is null)
            {
                return NotFound("products not found");
            }

            return Ok(productDto);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductById(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto is null)
            {
                return NotFound("product not found");
            }

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> GetProductPost([FromBody] ProductDTO productDto) //frombody significa que estou passando os dados do produto que estou incluindo
        {
            if (productDto is null)
            {
                return BadRequest("Invalid data");
            }

            await _productService.GetProductAdd(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto); //Getcategory é para retornar a categoria que foi incluida com o id da categoria getcategory
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> GetProductUpdate(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("data invalid");
            }

            if (productDto == null)
            {
                return BadRequest("Data invalid");
            }

            await _productService.GestProductUpdate(productDto);

            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProductDelete(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto is null)
            {
                return NotFound("product not found");
            }

            await _productService.GetProductRemove(id);

            return Ok(productDto);
        }
    }
}
