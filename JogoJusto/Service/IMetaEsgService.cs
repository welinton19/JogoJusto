using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IMetaEsgService
{
    Task CreateAsync(MetaEsgCreateViewModel vm);
    Task UpdateAsync(MetaEsgUpdateViewModel vm);
    Task DeleteAsync(int id);

    Task<MetaEsgViewModel?> GetByIdAsync(int id);
    Task<PagedResult<MetaEsgViewModel>> GetAllAsync(int pageNumber, int pageSize);
}
