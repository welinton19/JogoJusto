using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IMetaEsgRepository
{
    Task CreateAsync(MetaEsgModel meta);
    Task UpdateAsync(MetaEsgModel meta);
    Task<MetaEsgModel?> GetByIdAsync(int id);
    Task<PagedResult<MetaEsgModel>> GetAllAsync(int page, int size);
    Task SoftDeleteAsync(int id);
}
