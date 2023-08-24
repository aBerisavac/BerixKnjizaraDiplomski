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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.CustomerId)
               .IsRequired();
            builder.Property(x => x.ShippingMethodId)
                .IsRequired();

            builder.HasMany(x => x.OrderInvoices)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Customer);
            builder.HasOne(x => x.ShippingMethod);

        }
    }
}
