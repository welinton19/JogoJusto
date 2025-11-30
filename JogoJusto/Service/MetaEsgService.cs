using AutoMapper;
using JogoJusto.AppDta.Repository;
using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class MetaEsgService : IMetaEsgService
{
	private readonly IMetaEsgRepository _repo;
	private readonly IMapper _mapper;

	public MetaEsgService(IMetaEsgRepository repo, IMapper mapper)
	{
		_repo = repo;
		_mapper = mapper;
	}

	public async Task CreateAsync(MetaEsgCreateViewModel vm)
	{
		var model = _mapper.Map<MetaEsgModel>(vm);
		model.AtualizacaoDados = DateTime.UtcNow;
		model.StatusRegistro = "Ativo";

		await _repo.CreateAsync(model);
	}

	public async Task UpdateAsync(MetaEsgUpdateViewModel vm)
	{
		var existing = await _repo.GetByIdAsync(vm.IdMetaEsg);

		if (existing == null)
			throw new Exception("Meta ESG não encontrada");


        existing.AtualizacaoDados = DateTime.UtcNow;

        _mapper.Map(vm, existing);


		await _repo.UpdateAsync(existing);
	}

	public async Task DeleteAsync(int id)
	{
		await _repo.SoftDeleteAsync(id);
	}

	public async Task<MetaEsgViewModel?> GetByIdAsync(int id)
	{
		var model = await _repo.GetByIdAsync(id);
		return model == null ? null : _mapper.Map<MetaEsgViewModel>(model);
	}

	public async Task<PagedResult<MetaEsgViewModel>> GetAllAsync(int page, int size)
	{
		var paged = await _repo.GetAllAsync(page, size);

		return new PagedResult<MetaEsgViewModel>
		{
			Items = paged.Items.Select(_mapper.Map<MetaEsgViewModel>).ToList(),
			PageNumber = paged.PageNumber,
			PageSize = paged.PageSize,
			TotalCount = paged.TotalCount
		};
	}
}
