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
  public class HomeParagraphConiguration : IEntityTypeConfiguration<HomeParagraph>
  {
    public void Configure(EntityTypeBuilder<HomeParagraph> builder)
    {
      builder.Property(x => x.Paragraph).IsRequired().HasMaxLength(1000);
    }
  }
}
