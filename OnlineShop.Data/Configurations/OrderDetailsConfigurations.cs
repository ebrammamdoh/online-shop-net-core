using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Configurations
{
    public class OrderDetailsConfigurations : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ItemPrice).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.TotalAfterDiscount).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.SubTotal).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Tax).IsRequired();
            builder.Property(p => p.Discount).IsRequired();
        }
    }
}
