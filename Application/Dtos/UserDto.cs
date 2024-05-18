using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }

    public class UserRegisterDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
    public class UserViewDto
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Status { get; set; } = null!;

    }
    public class UserLoginViewDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;

        public string Position { get; set; } = null!;
        public string Status { get; set; } = null!;

    }

}