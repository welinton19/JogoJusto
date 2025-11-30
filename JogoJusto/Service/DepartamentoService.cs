using AutoMapper;
using JogoJusto.AppDta.Repository;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentoRepository _repo;
    private readonly IMapper _mapper;

    public DepartamentoService(IDepartamentoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task UpdateAsync(DepartamentoUpdateViewModel vm)
    {
        var existing = await _repo.GetByIdAsync(vm.IdDepartamento);
        if (existing == null)
            throw new Exception("Departamento não encontrado.");

        _mapper.Map(vm, existing);
        await _repo.UpdateAsync(existing);
    }

    public async Task<DepartamentoViewModel?> GetByIdAsync(int id)
    {
        var model = await _repo.GetByIdAsync(id);
        return model == null ? null : _mapper.Map<DepartamentoViewModel>(model);
    }

    public async Task<PagedResult<DepartamentoViewModel>> GetAllAsync(int page, int size)
    {
        var paged = await _repo.GetAllAsync(page, size);

        var vmItems = paged.Items.Select(_mapper.Map<DepartamentoViewModel>).ToList();

        return new PagedResult<DepartamentoViewModel>
        {
            PageNumber = paged.PageNumber,
            PageSize = paged.PageSize,
            TotalCount = paged.TotalCount,
            Items = vmItems
        };
    }
}

