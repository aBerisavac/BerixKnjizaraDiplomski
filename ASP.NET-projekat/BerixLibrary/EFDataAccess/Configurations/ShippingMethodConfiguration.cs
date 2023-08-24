using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Configurations
{
    public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cost).IsRequired();

            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.ShippingMethod)
                .HasForeignKey(x => x.ShippingMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
