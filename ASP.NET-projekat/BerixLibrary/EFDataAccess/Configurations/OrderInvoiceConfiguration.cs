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
    public class OrderInvoiceConfiguration : IEntityTypeConfiguration<OrderInvoice>
    {
        public void Configure(EntityTypeBuilder<OrderInvoice> builder)
        {
            builder.Property(x => x.NumberOfItems)
                .IsRequired();

            builder.HasIndex(x => x.NumberOfItems);

            builder.HasOne(x => x.Book);
            builder.HasOne(x => x.Order);
        }
    }
}
