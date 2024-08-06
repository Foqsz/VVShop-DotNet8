using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VVShop.WebMvc.Models;
using VVShop.WebMvc.Roles;
using VVShop.WebMvc.Services.Interfaces;

namespace VVShop.WebMvc.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        { 
            var result = await _productService.GetAllProducts(await GetAcessToken());

            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }  

        [HttpGet]
        public async Task<IActionResult> CreateProdut()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(await GetAcessToken()), "CategoryId", "Name");

            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> CreateProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateProduct(productVM, await GetAcessToken());

                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(await GetAcessToken()), "CategoryId", "Name");
            }
            return View(productVM);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(await GetAcessToken()), "CategoryId", "Name");

            var result = await _productService.FindProductbyId(id, await GetAcessToken());

            if (result is null)
            {
                return View("Error");
            }
            return View(result);    
        }

        [HttpPost] 
        public async Task<IActionResult> UpdateProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProduct(productVM, await GetAcessToken());

                if (result is null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(productVM);
        }

        [HttpGet] 
        public async Task<ActionResult<ProductViewModel>> DeleteProduct(int id)
        {
            var result = await _productService.FindProductbyId(id, await GetAcessToken());

            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpPost(), ActionName("DeleteProduct")] 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productService.DeleteProductById(id, await GetAcessToken());
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        private async Task<string> GetAcessToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }
}
