using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Entities;
using System.Collections.Generic;

namespace OnlineShop.Data.Configurations
{
    public class ItemConfigurations : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.AttributeNameItems).WithOne(p => p.Item).HasForeignKey(p => p.ItemId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.OrderDetails).WithOne(p => p.Item).HasForeignKey(p => p.ItemId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.UOM).WithMany(p => p.Items).HasForeignKey(p => p.UOMId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Qty).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.UnitPrice).HasColumnType("money").HasColumnType("decimal(18,4)").IsRequired();
        }
    }
}
