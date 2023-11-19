namespace Application.Common.Helpers.Pagination;

public record RequestPagination
{
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 20;
}