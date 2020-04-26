using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class JobsController : BaseApiController
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
      var dtos = _mapper.Map<IReadOnlyList<Job>, IReadOnlyList<JobToReturnDto>>(jobs);

      return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<JobToReturnDto>> GetJob(int id)
    {
      var spec = new JobsWithCategoryStateLocationsProductsSpecification(id);
      var job = await _jobsRepo.GetEntityWithSpec(spec);
      if (job == null)
      {
        var notFoundCode = (int)HttpStatusCode.NotFound;
        var apiResponse = new ApiResponse(notFoundCode);

        return NotFound(apiResponse);
      }

      var dto = _mapper.Map<Job, JobToReturnDto>(job);

      return Ok(dto);
    }
  }
}