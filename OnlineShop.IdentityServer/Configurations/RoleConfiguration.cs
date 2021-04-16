using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.IdentityServer.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = ConstantRoles.Admin,
                NormalizedName = ConstantRoles.Admin.ToUpper()
            },
            new IdentityRole
            {
                Name = ConstantRoles.Customer,
                NormalizedName = ConstantRoles.Customer.ToUpper()
            });
        }
    }
}
