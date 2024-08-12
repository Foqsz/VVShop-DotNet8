using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using VVShop.WebMvc.Models;
using VVShop.WebMvc.Services.Interfaces;

namespace VVShop.WebMvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]   
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            CartViewModel? cartVM = await GetCartByUser();

            if (cartVM is null)
            {
                ModelState.AddModelError("CartNotFound", "Does not exist a cart yet...Come on shopping");
                return View("/Views/Cart/CartNotFound.cshtml");
            }

            return View(cartVM);
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var result = await _cartService.RemoveItemFromCartAsync(id, string.Empty);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(id);
        }

        private async Task<CartViewModel?> GetCartByUser()
        {

            var cart = await _cartService.GetCartByUserIdAsync(GetUserId(), string.Empty);

            if (cart?.CartHeader is not null)
            {
                foreach (var item in cart.CartItems)
                {
                    cart.CartHeader.TotalAmount += (item.Product.Price * item.Quantity);
                }
            }
            return cart;
        }

        private async Task<string> GetAcessToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }

        private string GetUserId()
        {
            return User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
        }
    }
}
