using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, MenuViewDto>().ReverseMap();
        }
    }
}