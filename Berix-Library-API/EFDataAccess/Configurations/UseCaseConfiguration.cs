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
    internal class UseCaseConfiguration : IEntityTypeConfiguration<UseCase>
    {
        public void Configure(EntityTypeBuilder<UseCase> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Roles)
                .WithOne(x => x.UseCase)
                .HasForeignKey(x => x.UseCaseId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Logs)
                .WithOne(x => x.UseCase)
                .HasForeignKey(x => x.UseCaseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
