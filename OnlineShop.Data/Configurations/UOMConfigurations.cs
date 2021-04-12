using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Configurations
{
    public class UOMConfigurations : IEntityTypeConfiguration<UOM>
    {
        public void Configure(EntityTypeBuilder<UOM> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.OrderDetails).WithOne(p => p.UOM).HasForeignKey(p => p.UOMId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.Items).WithOne(p => p.UOM).HasForeignKey(p => p.UOMId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
