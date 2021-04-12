using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineShop.IdentityServer.Models;
using OnlineShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.IdentityServer.Data
{
    public class SeedData
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(Roles.Admin.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Admin.ToString();
                role.NormalizedName = "Admin.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync(Roles.Customer.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Customer.ToString();
                role.NormalizedName = "Customer";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
