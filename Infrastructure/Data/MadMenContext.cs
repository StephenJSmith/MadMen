using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class MadMenContext : DbContext
  {
    public MadMenContext(DbContextOptions<MadMenContext> options)
        : base(options)
    { }

    public DbSet<Job> Jobs { get; set; }
  }
}