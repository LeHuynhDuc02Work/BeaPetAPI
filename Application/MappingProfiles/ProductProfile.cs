using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<Product, ProductShopCartDto>().ReverseMap();
            CreateMap<Product, ProductOrderDetailDto>().ReverseMap();
        }
    }
}