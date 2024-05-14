using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserLoginViewDto> LoginAsync(UserLoginDto model)
        {
            var user = _context.Users.Where(x => x.Email.Trim() == model.Email.Trim()).FirstOrDefault();

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !passwordValid)
            { 
                return new UserLoginViewDto() {UserName = "", Email="", Token = ""};
            }

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddMinutes(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
            );
            return new UserLoginViewDto()
            {
                Id = user?.Id,
                UserName = user?.UserName,
                Email = user?.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Position = (user?.Email.Trim() == "ducle1701work@gmail.com") ? "admin" : "customer"
                }; 
        }

        public async Task<UserViewDto> RegisterAsync(UserRegisterDto model)
        {
            var userCheck = _context.Users.Where(x => x.Email.Trim() == model.Email.Trim()).FirstOrDefault();

            if (userCheck != null)
            {
                return new UserViewDto() { Status = "Email đã được đăng ký vui lòng dùng email khác!" };
            }    

            var user = new User { UserName = model.UserName, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //kiểm tra role Customer đã có
                if (!await _roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Customer));
                }

                await _userManager.AddToRoleAsync(user, AppRole.Customer);

                if (user.Email == "ducle1701work@gmail.com")
                {
                    if (!await _roleManager.RoleExistsAsync(AppRole.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
                    }

                    await _userManager.AddToRoleAsync(user, AppRole.Admin);
                }
            }
            else
            {
                return new UserViewDto() { Status = "Username không được để khoảng trắng!!" };
            }    
            var _user = _mapper.Map<UserViewDto>(user);
            _user.Status = "Đăng ký thành công!";
            return _user;
        }
    }
}