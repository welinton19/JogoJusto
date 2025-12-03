using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IEsgLogRepository
{
    Task<PagedResult<EsgLogModel>> GetEsgLogsAsync(int pageNumber, int pageSize);

}
