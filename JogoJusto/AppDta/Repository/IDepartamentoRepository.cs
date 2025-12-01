using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IDepartamentoRepository
{
    Task<DepartamentoModel?> GetByIdAsync(int id);
    Task<PagedResult<DepartamentoModel>> GetAllAsync(int pageNumber, int pageSize);
    Task UpdateAsync(DepartamentoModel dept);
}
