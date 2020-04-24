using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly MadMenContext _context;
    public JobsController(MadMenContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Job>>> GetJobs() {
      var jobs = await _context.Jobs.ToListAsync();

        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetJob(int id) {
      var job = await _context.Jobs.FindAsync(id);

        return Ok(job);
    }
  }
}