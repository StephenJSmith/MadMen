using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class JobStateConfiguration : IEntityTypeConfiguration<JobState>
  {
    public void Configure(EntityTypeBuilder<JobState> builder)
    {
        builder.Property(js => js.Id).IsRequired();
        builder.Property(js => js.Name).IsRequired();
        builder.Property(js => js.SortOrder).IsRequired();
    }
  }
}