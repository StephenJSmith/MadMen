namespace Core.Entities
{
  public class JobCategory : BaseEntity
  {
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
  }
}