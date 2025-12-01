using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IEmpresaRepository
{
    Task<EmpresaModel?> GetByIdAsync(int id);
    Task<PagedResult<EmpresaModel>> GetAllAsync(int pageNumber, int pageSize);
    Task CreateAsync(EmpresaModel empresa);
    Task UpdateAsync(EmpresaModel empresa);
    Task DeleteAsync(int id);
}
