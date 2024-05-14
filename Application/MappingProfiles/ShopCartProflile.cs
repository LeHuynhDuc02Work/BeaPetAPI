using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class ShopCartProflile : Profile
    {
        public ShopCartProflile()
        {
            CreateMap<ShopCart, ShopCartDto>().ReverseMap();
            CreateMap<ShopCart, ShopCartViewDto>().ReverseMap();
            CreateMap<ShopCart, ShopCartUpdateDto>().ReverseMap();
        }
    }
}