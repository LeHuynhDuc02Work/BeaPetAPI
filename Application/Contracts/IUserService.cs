using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterAsync(UserRegisterDto model);

        public Task<string> LoginAsync(UserLoginDto model);
    }
}