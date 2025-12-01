using JogoJusto.DTO;
using JogoJusto.Pagination;

namespace JogoJusto.Service
{
    public interface IDiversidadeService
    {
        Task<DiversidadeDTO> GerarIndicadoresAsync(int pageNumber, int pageSize);
        Task<InsightsResponseDTO> GerarInsightsAsync();
        Task <PagedResult<RankingDiversidadeDTO>> GerarRankingAsync(int pageNumber, int pageSize);
        Task<TreinamentosResponseDTO> GerarTreinamentosAsync();
    }
}
