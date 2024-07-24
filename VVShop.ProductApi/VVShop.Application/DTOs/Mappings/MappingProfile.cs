using AutoMapper;
using VVShop.ProductApi.VVShop.Application.DTOs;
using VVShop.ProductApi.VVShop.Core.Models;

namespace VVShop.ProductApi.VVShop.Application.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
            CreateMap<ProductModel, ProductDTO>().ReverseMap();
        }
    }
}
