using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly IGenericRepository<Job> _jobsRepo;
    private readonly IMapper _mapper;
    public JobsController(IGenericRepository<Job> jobsRepo, IMapper mapper)
    {
      _mapper = mapper;
      _jobsRepo = jobsRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<JobToReturnDto>>> GetJobs()
    {
      var spec = new JobsWithCategoryStateLocationsProductsSpecification();
      var jobs = await _jobsRepo.ListAsync(spec);
      var dtos = jobs.Select(job => new JobToReturnDto
      {
        Id = job.Id,
        Name = job.Name,
        Description = job.Description,
        JobCategory = job.JobCategory.Name,
        JobState = job.JobState.Name,
        IsAutoJobStateId = job.IsAutoJobStateId,
        Location = job.Location.Name,
        Product = job.Product.Name
      });

      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobToReturnDto>> GetJob(int id)
    {
      var spec = new JobsWithCategoryStateLocationsProductsSpecification(id);
      var job = await _jobsRepo.GetEntityWithSpec(spec);
      var dto = _mapper.Map<Job, JobToReturnDto>(job);

      return Ok(dto);
    }
  }
}