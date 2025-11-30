using JogoJusto.Models;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta.Repository;

public class DesenvolvimentoRepository : IDesenvolvimentoRepository
{
    private readonly JogoJustoDbContext _context;

    public DesenvolvimentoRepository(JogoJustoDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(DesenvolvimentoModel model)
    {
        await _context.Desenvolvimento.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DesenvolvimentoModel model)
    {
        _context.Desenvolvimento.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dev = await GetByIdAsync(id);
        if (dev != null)
        {
            _context.Desenvolvimento.Remove(dev);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<DesenvolvimentoModel?> GetByIdAsync(int id)
    {
        return await _context.Desenvolvimento
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdDesenvolvimento == id);
    }

    public async Task<PagedResult<DesenvolvimentoModel>> GetAllAsync(int page, int size)
    {
        var query = _context.Desenvolvimento
            .AsNoTracking()
            .OrderBy(x => x.IdDesenvolvimento);

        var total = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return new PagedResult<DesenvolvimentoModel>
        {
            Items = items,
            PageNumber = page,
            PageSize = size,
            TotalCount = total
        };
    }
}

