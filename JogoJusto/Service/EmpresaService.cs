using AutoMapper;
using JogoJusto.AppDta.Repository;
using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repo;
    private readonly IMapper _mapper;

    public EmpresaService(IEmpresaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task CreateAsync(EmpresaCreateViewModel vm)
    {
        var model = _mapper.Map<EmpresaModel>(vm);
        await _repo.CreateAsync(model);
    }

    public async Task UpdateAsync(EmpresaUpdateViewModel vm)
    {
        var existing = await _repo.GetByIdAsync(vm.EmpresaId);

        if (existing == null)
            throw new Exception("Empresa não encontrada.");

        _mapper.Map(vm, existing);
        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }

    public async Task<EmpresaViewModel?> GetByIdAsync(int id)
    {
        var model = await _repo.GetByIdAsync(id);
        return model == null ? null : _mapper.Map<EmpresaViewModel>(model);
    }

    public async Task<PagedResult<EmpresaViewModel>> GetAllAsync(int pageNumber, int pageSize)
    {
        var pagedModels = await _repo.GetAllAsync(pageNumber, pageSize);

        var vmItems = pagedModels.Items.Select(e => _mapper.Map<EmpresaViewModel>(e));

        return new PagedResult<EmpresaViewModel>
        {
            PageNumber = pagedModels.PageNumber,
            PageSize = pagedModels.PageSize,
            TotalCount = pagedModels.TotalCount,
            Items = vmItems.ToList()
        };
    }
}

