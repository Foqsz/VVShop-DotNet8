namespace VVShop.CartApi.Models;

public class Cart
{
    public CartHeader CartHeader { get; set; } = new CartHeader();
    public IEnumerable<CartItem> cartItems { get; set; } = Enumerable.Empty<CartItem>();
}
