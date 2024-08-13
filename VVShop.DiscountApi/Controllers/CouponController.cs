using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VVShop.DiscountApi.DTOs;
using VVShop.DiscountApi.Repositories.Interfaces;

namespace VVShop.DiscountApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
    private ICouponRepository _repository;

    public CouponController(ICouponRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("couponCode")]
    [Authorize]
    public async Task<ActionResult<CouponDTO>> GetDiscountCouponByCode(string couponCode)
    {
        var coupon = await _repository.GetCouponByCode(couponCode);

        if (coupon is null)
        {
            return NotFound($"Coupon Code: {couponCode} not found");
        }
        return Ok(coupon);
    }
}
