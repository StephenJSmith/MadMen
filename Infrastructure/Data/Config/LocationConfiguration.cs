using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class LocationConfiguration : IEntityTypeConfiguration<Location>
  {
    public void Configure(EntityTypeBuilder<Location> builder)
    {
      builder.Property(l => l.Id).IsRequired();
      builder.Property(l => l.Name).IsRequired();
      builder.Property(l => l.DisplayOrder).IsRequired();
    }
  }
}