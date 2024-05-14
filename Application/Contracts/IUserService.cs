using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts
{
    public interface IUserService
    {
        public Task<UserViewDto> RegisterAsync(UserRegisterDto model);

        public Task<UserLoginViewDto> LoginAsync(UserLoginDto model);
    }
}