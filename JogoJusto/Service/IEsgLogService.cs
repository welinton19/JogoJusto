using JogoJusto.DTO;
using JogoJusto.Pagination;

namespace JogoJusto.Service;

public interface IEsgLogService
{
    Task<PagedResult<EsgLogDTO>> GetEsgLogsAsync(int pageNumber, int pageSize);

}
