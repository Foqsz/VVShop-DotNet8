using VVShop.CartApi.DTOs;

namespace VVShop.CartApi.Repositories;

public interface ICartRepository
{
    /// <summary>
    /// CartDTO aqui é para retornar um CartDTO.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<CartDTO> GetCartByUserIdAsync(string userId);
    Task<CartDTO> UpdateCartAsync(CartDTO cart);

    /// <summary>
    /// Ao limpar o carrinho do usuario, vai retornar true ou falso, por isso o bool
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<bool> CleanCartAsync(string userId);
    Task<bool> DeleteItemCartAsync(int cartItemId);

    Task<bool> ApplyCouponAsync(string userId, string couponCode);
    Task<bool> DeleteCouponAsync(string userId);
}
