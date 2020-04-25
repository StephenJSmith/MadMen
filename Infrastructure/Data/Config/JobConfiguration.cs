using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class JobConfiguration : IEntityTypeConfiguration<Job>
  {
    public void Configure(EntityTypeBuilder<Job> builder)
    {
      builder.Property(j => j.Id).IsRequired();
      builder.Property(j => j.Name).IsRequired();
      builder
        .HasOne(j => j.JobCategory)
        .WithMany()
        .HasForeignKey(j => j.JobCategoryId);
      builder
          .HasOne(j => j.JobState)
          .WithMany()
          .HasForeignKey(j => j.JobStateId);
      builder
          .HasOne(j => j.Location)
          .WithMany()
          .HasForeignKey(j => j.LocationId);
      builder
          .HasOne(j => j.Product)
          .WithMany()
          .HasForeignKey(j => j.ProductId);
    }
  }
}