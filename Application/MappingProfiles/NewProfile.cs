using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class NewProfile : Profile
    {
        public NewProfile()
        {
            CreateMap<New, NewDto>().ReverseMap();
            CreateMap<New, NewViewDto>().ReverseMap();
        }
    }
}