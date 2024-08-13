using AutoMapper;
using VVShop.DiscountApi.Models;

namespace VVShop.DiscountApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CouponDTO, Coupon>().ReverseMap();
    }
}
