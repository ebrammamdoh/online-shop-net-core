using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.Configurations
{
    public class AttributeNameConfigurations : IEntityTypeConfiguration<AttributeName>
    {
        public void Configure(EntityTypeBuilder<AttributeName> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.AttributeNameItems).WithOne(p => p.AttributeName).HasForeignKey(p => p.AttributeNameId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Name).IsRequired();

        }
    }
}
