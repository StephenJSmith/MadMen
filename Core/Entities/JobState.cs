namespace Core.Entities
{
  public class JobState : BaseEntity
  {
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public int SortOrder { get; set; }
  }
}