namespace Application.Common.Helpers.Pagination;

public class ResponsePagination<T>
{
    public int Page { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<T> Records { get; set; } = Enumerable.Empty<T>();
}