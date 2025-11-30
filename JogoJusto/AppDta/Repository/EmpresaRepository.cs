using JogoJusto.Models;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta.Repository;

public class EmpresaRepository : IEmpresaRepository
{

    private readonly JogoJustoDbContext _jogodbcontext;

    public EmpresaRepository(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public async Task CreateAsync(EmpresaModel empresa)
    {
        await _jogodbcontext.Empresa.AddAsync(empresa);
        await _jogodbcontext.SaveChangesAsync();
    }

    public async Task UpdateAsync(EmpresaModel empresa)
    {
        _jogodbcontext.Empresa.Update(empresa);
        await _jogodbcontext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _jogodbcontext.Empresa.Remove(entity);
            await _jogodbcontext.SaveChangesAsync();
        }
    }

    public async Task<EmpresaModel?> GetByIdAsync(int id)
    {
        return await _jogodbcontext.Empresa.FirstOrDefaultAsync(e => e.EmpresaId == id);
    }

    public async Task<PagedResult<EmpresaModel>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _jogodbcontext.Empresa
       .AsNoTracking()
       .OrderBy(e => e.EmpresaId);

        var total = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new EmpresaModel
            {
                EmpresaId = e.EmpresaId,
                Cnpj = e.Cnpj,
                InscricaoEstadual = e.InscricaoEstadual,
                Nome = e.Nome,
                Endereco = e.Endereco,
                Telefone = e.Telefone
            })
            .ToListAsync();

        return new PagedResult<EmpresaModel>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = total
        };

    }
}
