using Core.Entities;
using Core.Specfications;

namespace Core.Specifications
{
  public class JobsWithCategoryStateLocationsProductsSpecification : BaseSpecification<Job>
  {
    public JobsWithCategoryStateLocationsProductsSpecification(JobSpecParams specParams)
      : base(j =>
        (string.IsNullOrWhiteSpace(specParams.Search) || j.Name.ToLower().Contains(specParams.Search))
        && (!specParams.JobCategoryId.HasValue || j.JobCategoryId == specParams.JobCategoryId)
        && (!specParams.JobStateId.HasValue || j.JobStateId == specParams.JobStateId)
        && (!specParams.LocationId.HasValue || j.LocationId == specParams.LocationId)
        && (!specParams.ProductId.HasValue || j.ProductId == specParams.ProductId)
      )
    {
        AddInclude(j => j.JobCategory);
        AddInclude(j => j.JobState);
        AddInclude(j => j.Location);
        AddInclude(j => j.Product);
        AddOrderBy(j => j.Name);
        ApplyPaging(specParams.Skip, specParams.Take);

      if (!string.IsNullOrEmpty(specParams.Sort))
      {
        switch (specParams.Sort)
        {
          case "nameAsc":
            AddOrderBy(j => j.Name);
            break;

          case "nameDesc":
            AddOrderByDescending(j => j.Name);
            break;

          default:
            AddOrderBy(j => j.Name);
            break;
        }
      }
    }

    public JobsWithCategoryStateLocationsProductsSpecification(int id)
        : base(j => j.Id == id)
    {
        AddInclude(j => j.JobCategory);
        AddInclude(j => j.JobState);
        AddInclude(j => j.Location);
        AddInclude(j => j.Product);
    }
  }
}