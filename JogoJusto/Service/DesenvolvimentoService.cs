using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.AppDta.Repository;
using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;
public class DesenvolvimentoService : IDesenvolvimentoService
{
    private readonly IDesenvolvimentoRepository _repo;
    private readonly IMapper _mapper;

    public DesenvolvimentoService(IDesenvolvimentoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task CreateAsync(DesenvolvimentoCreateViewModel vm)
    {
        var model = _mapper.Map<DesenvolvimentoModel>(vm);

        model.DataRegistroDeDados = DateTime.UtcNow;

        await _repo.CreateAsync(model);
    }

    public async Task UpdateAsync(DesenvolvimentoUpdateViewModel vm)
    {
        var existing = await _repo.GetByIdAsync(vm.IdDesenvolvimento);

        if (existing == null)
            throw new Exception("Desenvolvimento não encontrado.");

        _mapper.Map(vm, existing);

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }

    public async Task<DesenvolvimentoViewModel?> GetByIdAsync(int id)
    {
        var model = await _repo.GetByIdAsync(id);

        return model == null ? null : _mapper.Map<DesenvolvimentoViewModel>(model);
    }

    public async Task<PagedResult<DesenvolvimentoViewModel>> GetAllAsync(int page, int size)
    {
        var paged = await _repo.GetAllAsync(page, size);

        return new PagedResult<DesenvolvimentoViewModel>
        {
            Items = paged.Items.Select(_mapper.Map<DesenvolvimentoViewModel>).ToList(),
            PageNumber = paged.PageNumber,
            PageSize = paged.PageSize,
            TotalCount = paged.TotalCount
        };
    }
}
