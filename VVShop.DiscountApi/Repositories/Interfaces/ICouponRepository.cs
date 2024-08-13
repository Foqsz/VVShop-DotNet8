using VVShop.DiscountApi.DTOs;

namespace VVShop.DiscountApi.Repositories.Interfaces;

public interface ICouponRepository
{
    Task<CouponDTO> GetCouponByCode(string couponCode);
}
