using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVShop.ProductApi.VVShop.Application.DTOs;
using VVShop.ProductApi.VVShop.Application.Services;
using VVShop.ProductApi.VVShop.Core.Roles; 

namespace VVShop.ProductApi.VVShop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
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
                return NotFound("products not found.");
            }

            return Ok(productDto);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductById(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto is null)
            {
                return NotFound("Product not found");
            }

            return Ok(productDto);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> GetProductPost([FromBody] ProductDTO productDto) //frombody significa que estou passando os dados do produto que estou incluindo
        {
            if (productDto is null)
            {
                return BadRequest("Invalid data");
            }

            await _productService.GetProductAdd(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto); //Getcategory é para retornar a categoria que foi incluida com o id da categoria getcategory
        }

        [HttpPut()]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> GetProductUpdate([FromBody] ProductDTO productDto)
        { 
            if (productDto == null)
            {
                return BadRequest("Data invalid");
            }

            await _productService.GetProductUpdate(productDto);

            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
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
