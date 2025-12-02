using JogoJusto.AppDta.Repository;
using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.Service
{
    public class EsgLogService : IEsgLogService
    {
        private readonly IEsgLogRepository _repo;

        public EsgLogService(IEsgLogRepository repo)
        {
            _repo = repo;
        }

        public Task<PagedResult<EsgLogModel>> GetEsgLogsAsync(int pageNumber, int pageSize)
        {
            return _repo.GetEsgLogsAsync(pageNumber, pageSize);
        }
    }
}
