using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderViewDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
        }
    }
}