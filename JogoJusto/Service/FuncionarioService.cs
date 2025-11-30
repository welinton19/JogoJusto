using AutoMapper;
using JogoJusto.AppDta.Repository;
using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _repo;
    private readonly IMapper _mapper;

    public FuncionarioService(IFuncionarioRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task CreateAsync(FuncionarioCreateViewModel vm)
    {
        var model = _mapper.Map<FuncionarioModel>(vm);
        await _repo.CreateAsync(model);
    }

    public async Task UpdateAsync(FuncionarioUpdateViewModel vm)
    {
        var existing = await _repo.GetByIdAsync(vm.FuncionarioId);

        if (existing == null)
            throw new Exception("Funcionário não encontrado.");

        _mapper.Map(vm, existing);

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }

    public async Task<FuncionarioViewModel?> GetByIdAsync(int id)
    {
        var model = await _repo.GetByIdAsync(id);
        return model == null ? null : _mapper.Map<FuncionarioViewModel>(model);
    }

    public async Task<PagedResult<FuncionarioViewModel>> GetFuncionariosAsync(int page, int size)
    {
        var paged = await _repo.GetFuncionariosAsync(page, size);

        var vmItems = paged.Items.Select(f => _mapper.Map<FuncionarioViewModel>(f));

        return new PagedResult<FuncionarioViewModel>
        {
            PageNumber = paged.PageNumber,
            PageSize = paged.PageSize,
            TotalCount = paged.TotalCount,
            Items = vmItems
        };
    }
}
