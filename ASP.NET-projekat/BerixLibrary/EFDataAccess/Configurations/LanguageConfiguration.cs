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
  public class LanguageConfiguration : IEntityTypeConfiguration<Language>
  {
    public void Configure(EntityTypeBuilder<Language> builder)
    {
      builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

      builder.HasIndex(x => x.Name);

      builder.HasMany(x => x.Books)
          .WithOne(x => x.Language)
          .HasForeignKey(x => x.LanguageId)
          .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
