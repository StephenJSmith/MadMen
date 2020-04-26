using Core.Entities;
using Core.Specfications;

namespace Core.Specifications
{
  public class JobsWithCategoryStateLocationsProductsSpecification : BaseSpecification<Job>
  {
    public JobsWithCategoryStateLocationsProductsSpecification()
    {
        AddInclude(j => j.JobCategory);
        AddInclude(j => j.JobState);
        AddInclude(j => j.Location);
        AddInclude(j => j.Product);
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