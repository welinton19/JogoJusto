using JogoJusto.DTO;

namespace JogoJusto.Service
{
    public interface IDiversidadeService
    {
        Task<DiversidadeDTO> GerarIndicadoresAsync(int pageNumber, int pageSize);
    }
}
