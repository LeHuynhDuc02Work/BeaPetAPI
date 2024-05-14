using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodDto>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodViewDto>().ReverseMap();
        }
    }
}
