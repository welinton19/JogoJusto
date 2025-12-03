using JogoJusto.AppDta.Repository;
using JogoJusto.DTO;
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

        public async Task<PagedResult<EsgLogDTO>> GetEsgLogsAsync(int page, int size)
        {
            var result = await _repo.GetEsgLogsAsync(page, size);

            var mapped = result.Items.Select(e => new EsgLogDTO
            {
                Id = e.IdEsgLog,
                Departamento = e.Departamento.NomeDepartamento,
                Empresa = e.Departamento.Empresa.Nome,
                Acao = e.AcaoRealizada,
                Recomendacao = e.Recomendacao,
                Data = e.DataAcao
            }).ToList();

            return new PagedResult<EsgLogDTO>
            {
                Items = mapped,
                TotalCount = result.TotalCount,
                PageNumber = page,
                PageSize = size
            };
        }

    }

}