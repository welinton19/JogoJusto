using JogoJusto.Models;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta.Repository
{
    public class EsgLogRepository : IEsgLogRepository
    {
        private readonly JogoJustoDbContext _jogodbcontext;

        public EsgLogRepository(JogoJustoDbContext jogodbcontext)
        {
            _jogodbcontext = jogodbcontext;
        }

        public async Task<PagedResult<EsgLogModel>> GetEsgLogsAsync(int pageNumber, int pageSize)
        {
            var query = _jogodbcontext.EsgLogModel.AsQueryable();

            int total = await query.CountAsync();

            var items = await query
                .OrderByDescending(e => e.DataAcao)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<EsgLogModel>
            {
                Items = items,
                TotalCount = total
            };
        }
    }
}
