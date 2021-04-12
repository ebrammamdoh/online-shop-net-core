using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Entities;
using OnlineShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.OrderDetails).WithOne(p => p.OrderHeader).HasForeignKey(p => p.OrderHeaderId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.DiscountValue).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.DiscountValue).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.RequestDate);
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.DuoDate);
        }
    }
}
