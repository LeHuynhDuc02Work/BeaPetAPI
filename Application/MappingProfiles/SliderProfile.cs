using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Slider, SliderViewDto>().ReverseMap();
        }
    }
}