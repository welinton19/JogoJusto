using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.Service;

public interface IEsgLogService
{
    Task<PagedResult<EsgLogModel>> GetEsgLogsAsync(int pageNumber, int pageSize);

}
