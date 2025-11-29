using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.AppDta.Repository;

public interface IFuncionarioRepository
{
    Task<FuncionarioModel?> GetByIdAsync(int id);
    Task <PagedResult<FuncionarioViewModel>> GetFuncionariosAsync(int pageNumber, int pageSize);
    Task CreateAsync(FuncionarioModel funcionario);
    Task UpdateAsync(FuncionarioModel funcionario);
    Task DeleteAsync(int id);
}
