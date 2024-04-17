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
        }
    }
}