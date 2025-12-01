using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IEmpresaService
{
    Task CreateAsync(EmpresaCreateViewModel vm);
    Task UpdateAsync(EmpresaUpdateViewModel vm);
    Task <EmpresaViewModel?>GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task <PagedResult<EmpresaViewModel>>GetAllAsync(int pageNumber, int pageSize);
}
