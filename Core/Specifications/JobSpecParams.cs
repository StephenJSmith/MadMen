namespace Core.Specfications
{
  public class JobSpecParams
  {
    private const int MaxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 6;
    public int PageSize
    {
      get => _pageSize;
      set => _pageSize = (value > MaxPageSize)
          ? MaxPageSize
          : value;
    }
    public int Skip
    {
      get => PageSize * (PageNumber - 1);
    }
    public int Take
    {
      get => PageSize;
    }

    public int? JobCategoryId { get; set; }
    public int? JobStateId { get; set; }
    public int? LocationId { get; set; }
    public int? ProductId { get; set; }
    public string Sort { get; set; }
    private string _search;
    public string Search
    {
      get => _search;
      set => _search = value.ToLower();
    }
  }
}