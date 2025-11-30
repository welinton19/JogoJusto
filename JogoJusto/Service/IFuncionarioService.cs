using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IFuncionarioService
{
    Task<FuncionarioViewModel?> GetByIdAsync(int id);
    Task<PagedResult<FuncionarioViewModel>> GetFuncionariosAsync(int page, int size);
    Task CreateAsync(FuncionarioCreateViewModel vm);
    Task UpdateAsync(FuncionarioUpdateViewModel vm);
    Task DeleteAsync(int id);
}
