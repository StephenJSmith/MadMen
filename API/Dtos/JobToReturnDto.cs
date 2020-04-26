namespace API.Dtos
{
    public class JobToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string JobCategory { get; set; }
        public string JobState { get; set; }
        public bool IsAutoJobStateId { get; set; }
        public string Location { get; set; }
        public string Product { get; set; }
     }
}