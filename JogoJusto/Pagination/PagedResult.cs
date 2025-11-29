namespace JogoJusto.Pagination;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalCount { get; set; }         
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? NextPage { get; set; }
    public string? PreviousPage { get; set; }

}
