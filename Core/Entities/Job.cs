namespace Core.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public JobCategory JobCategory { get; set; }
        public int JobCategoryId { get; set; }
        public JobState JobState { get; set; }
        public int JobStateId { get; set; }
        public bool IsAutoJobStateId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}