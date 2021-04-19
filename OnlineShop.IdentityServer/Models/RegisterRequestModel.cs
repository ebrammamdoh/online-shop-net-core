using OnlineShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.IdentityServer.Models
{
    public class RegisterRequestModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public Roles Roles { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string DescriptionEn { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string DescriptionAr { get; set; }
    }
}
