using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
  {
    public void Configure(EntityTypeBuilder<JobCategory> builder)
    {
        builder.Property(jc => jc.Id).IsRequired();
        builder.Property(jc => jc.Name).IsRequired();
        builder.Property(jc => jc.DisplayOrder).IsRequired();
    }
  }
}