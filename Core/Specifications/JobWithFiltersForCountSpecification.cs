using Core.Entities;
using Core.Specfications;

namespace Core.Specifications
{
  public class JobWithFiltersForCountSpecification : BaseSpecification<Job>
  {
    public JobWithFiltersForCountSpecification(JobSpecParams specParams)
      : base(j =>
        (string.IsNullOrWhiteSpace(specParams.Search) || j.Name.ToLower().Contains(specParams.Search))
        && (!specParams.JobCategoryId.HasValue || j.JobCategoryId == specParams.JobCategoryId)
        && (!specParams.JobStateId.HasValue || j.JobStateId == specParams.JobStateId)
        && (!specParams.LocationId.HasValue || j.LocationId == specParams.LocationId)
        && (!specParams.ProductId.HasValue || j.ProductId == specParams.ProductId)
    ) { }
  }
}