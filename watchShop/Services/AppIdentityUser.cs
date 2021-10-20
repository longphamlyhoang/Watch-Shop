using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace watchShop.Services
{
    public class AppIdentityUser : IdentityUser
    {
        [MaxLength(300)]
        public string Avatar { get; set; }
    }
}