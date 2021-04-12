using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.IdentityServer.Models
{
    public class RegisterRequestViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
