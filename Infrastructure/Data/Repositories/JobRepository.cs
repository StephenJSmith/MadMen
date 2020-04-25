using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
  public class JobRepository : IJobRepository

  {
    private readonly MadMenContext _context;
    public JobRepository(MadMenContext context)
    {
      _context = context;
    }

    public async Task<Job> GetJobById(int id)
    {
      var job = await _context.Jobs.FindAsync(id);

      return job;
    }

    public async Task<IReadOnlyList<Job>> GetJobs()
    {
      var jobs = await _context.Jobs.ToListAsync();

      return jobs;
    }
  }
}