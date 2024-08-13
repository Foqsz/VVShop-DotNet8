using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VVShop.DiscountApi.Context;
using VVShop.DiscountApi.DTOs;
using VVShop.DiscountApi.Repositories.Interfaces;

namespace VVShop.DiscountApi.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly AppDbContext _context;
    private IMapper _mapper;

    public CouponRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CouponDTO> GetCouponByCode(string couponCode)
    {
        var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode); //FirstOrDefaultAsync para localizar a primeira ocorrencia

        return _mapper.Map<CouponDTO>(coupon);
    }
}
