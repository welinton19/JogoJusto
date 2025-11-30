using JogoJusto.AppDta;
using JogoJusto.AppDta.Repository;
using JogoJusto.Models;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

public class MetaEsgRepository : IMetaEsgRepository
{
    private readonly JogoJustoDbContext _context;

    public MetaEsgRepository(JogoJustoDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(MetaEsgModel meta)
    {
        await _context.MetaEsg.AddAsync(meta);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MetaEsgModel meta)
    {
        _context.MetaEsg.Update(meta);
        await _context.SaveChangesAsync();
    }

    public async Task<MetaEsgModel?> GetByIdAsync(int id)
    {
        return await _context.MetaEsg
            .Where(m => m.IdMetaEsg == id && m.StatusRegistro == "Ativo")
            .FirstOrDefaultAsync();
    }

    public async Task<PagedResult<MetaEsgModel>> GetAllAsync(int page, int size)
    {
        var query = _context.MetaEsg
            .Where(m => m.StatusRegistro == "Ativo")
            .OrderBy(m => m.IdMetaEsg);

        var total = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return new PagedResult<MetaEsgModel>
        {
            Items = items,
            PageNumber = page,
            PageSize = size,
            TotalCount = total
        };
    }

    public async Task SoftDeleteAsync(int id)
    {
        var entity = await _context.MetaEsg.FindAsync(id);
        if (entity != null)
        {
            entity.StatusRegistro = "Inativo";
            entity.AtualizacaoDados = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}

