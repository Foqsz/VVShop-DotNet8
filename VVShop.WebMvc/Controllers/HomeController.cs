using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VVShop.WebMvc.Models;
using VVShop.WebMvc.Services.Interfaces;

namespace VVShop.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts(string.Empty);

            if (products is null)
            {
                return View("Error");
            }
            return View(products);
        }

        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> ProductDetails(int id)
        {
            var product = await _productService.FindProductbyId(id, string.Empty); //string empty é valor nulo, n preciso do token aqui

            if (product is null)
            {
                return View("Error");
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("ProductDetails")]
        public async Task<ActionResult<ProductViewModel>> ProductDetailsPost(ProductViewModel productVM)
        {
            CartViewModel cart = new()
            {
                CartHeader = new CartHeaderViewModel
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CartItemViewModel cartItem = new() // () = nova notação para instanciar classe
            {
                Quantity = productVM.Quantity,
                ProductId = productVM.Id,
                Product = await _productService.FindProductbyId(productVM.Id, string.Empty)
            };

            List<CartItemViewModel> cartItemsVM = new List<CartItemViewModel>();
            cartItemsVM.Add(cartItem);
            cart.CartItems = cartItemsVM;

            var result = await _cartService.AddItemToCartAsync(cart, string.Empty);

            if (result is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var acessToken = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

    }
}
