using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Models.Accout
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remeber me")]
        public bool RemenberMe { get; set; }
        public string ReturnUrl { get; set; }
        public string[] Roles { get; set; }
    }
}
