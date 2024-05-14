using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewDto>().ReverseMap();
            CreateMap<User, UserLoginViewDto>().ReverseMap();
        }
    }
}
