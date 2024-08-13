using VVShop.WebMvc.Models;

namespace VVShop.WebMvc.Services.Interfaces;

public interface ICouponService
{
    Task<CouponViewModel> GetDiscountCoupon(string couponCode, string token);
}
