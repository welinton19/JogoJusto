using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IDesenvolvimentoRepository
{
    Task<DesenvolvimentoModel?> GetByIdAsync(int id);
    Task<PagedResult<DesenvolvimentoModel>> GetAllAsync(int page, int size);
    Task CreateAsync(DesenvolvimentoModel model);
    Task UpdateAsync(DesenvolvimentoModel model);
    Task DeleteAsync(int id);
}
