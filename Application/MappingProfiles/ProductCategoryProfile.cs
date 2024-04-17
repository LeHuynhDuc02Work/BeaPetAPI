using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryViewDto>().ReverseMap();
        }
    }
}