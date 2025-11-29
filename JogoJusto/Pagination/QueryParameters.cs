namespace JogoJusto.Pagination
{
    public record QueryParameters(
        int PageNumber = 1,
        int PageSize = 10
    );

}
