using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class User : IdentityUser
    {
        public string? Status { get; set; }
        //public ICollection<ShopCart>? ShopCarts { get; set; }
    }
}