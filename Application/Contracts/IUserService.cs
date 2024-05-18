using Application.Dtos;
using Core;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts
{
    public interface IUserService
    {
        public Task<UserViewDto> RegisterAsync(UserRegisterDto model);

        public Task<UserLoginViewDto> LoginAsync(UserLoginDto model);

        public Task<List<UserLoginViewDto>> GetAll(InputSearchDto inputSearch);

        public Task<bool> LockUser(string id);
    }
}