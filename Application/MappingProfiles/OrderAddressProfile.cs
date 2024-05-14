using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class OrderAddressProfile : Profile
    {
        public OrderAddressProfile()
        {
            CreateMap<OrderAddress, OrderAddressDto>().ReverseMap();
            CreateMap<OrderAddress, OrderAddressViewDto>().ReverseMap();
            CreateMap<OrderAddress, OrderAddressCreateDto>().ReverseMap();
        }
    }
}