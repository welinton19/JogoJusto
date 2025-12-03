using JogoJusto.DTO;
using JogoJusto.Pagination;

namespace JogoJusto.Service
{
    public interface IDiversidadeService
    {
        Task<DiversidadeDTO> GerarIndicadoresAsync(int pageNumber, int pageSize);
        Task<PagedResult<InsightDTO>> GerarInsightsAsync(int pageNumber, int pageSize);
        Task <PagedResult<RankingDiversidadeDTO>> GerarRankingAsync(int pageNumber, int pageSize);
        Task <PagedResult<TreinamentoDTO>> GerarTreinamentosAsync(int pageNumber, int pageSize);
    }
}
