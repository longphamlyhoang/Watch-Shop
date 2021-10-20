using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Models.Accout
{
    public class RegisterResult
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool Success => !string.IsNullOrEmpty(UserId);
        public string Message { get; set; }
        public RegisterResult()
        {
            UserId = string.Empty;
            Email = string.Empty;
            Message = "";
        }
    }
}
