using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailViewDto>().ReverseMap();
        }
    }
}