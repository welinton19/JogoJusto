using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IDesenvolvimentoService
{
    Task CreateAsync(DesenvolvimentoCreateViewModel vm);
    Task UpdateAsync(DesenvolvimentoUpdateViewModel vm);
    Task DeleteAsync(int id);

    Task<DesenvolvimentoViewModel?> GetByIdAsync(int id);
    Task<PagedResult<DesenvolvimentoViewModel>> GetAllAsync(int page, int size);
}
