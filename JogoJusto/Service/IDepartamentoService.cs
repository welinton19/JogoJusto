using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IDepartamentoService
{
    Task UpdateAsync(DepartamentoUpdateViewModel vm);
    Task<DepartamentoViewModel?> GetByIdAsync(int id);
    Task<PagedResult<DepartamentoViewModel>> GetAllAsync(int pageNumber, int pageSize);
}


