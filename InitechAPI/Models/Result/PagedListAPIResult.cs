namespace InitechAPI.Models
{
    public abstract class PagedListAPIResult : APIResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}