using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandViewDto>().ReverseMap();
        }
    }
}