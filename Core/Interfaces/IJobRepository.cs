using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IJobRepository
    {
         Task<Job> GetJobById(int id);
         Task<IReadOnlyList<Job>> GetJobs();
    }
}