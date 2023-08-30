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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);

            builder.HasMany(x=>x.Books)
                .WithOne(x=>x.Author)
                .HasForeignKey(x=>x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
