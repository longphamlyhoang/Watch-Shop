using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Models.Users
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Roles { get; set; }
    }
}
