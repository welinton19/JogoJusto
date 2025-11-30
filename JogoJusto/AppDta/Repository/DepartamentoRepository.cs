using JogoJusto.Models;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly JogoJustoDbContext _context;

    public DepartamentoRepository(JogoJustoDbContext context)
    {
        _context = context;
    }

    public async Task<DepartamentoModel?> GetByIdAsync(int id)
    {
        return await _context.Departamento
            .Include(d => d.Empresa)
            .Include(d => d.Funcionarios)
            .FirstOrDefaultAsync(d => d.IdDepartamento == id);
    }

    public async Task<PagedResult<DepartamentoModel>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Departamento
            .Include(d => d.Empresa)
            .Include(d => d.Funcionarios)
            .AsNoTracking()
            .OrderBy(d => d.IdDepartamento);

        var total = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<DepartamentoModel>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = total
        };
    }

    public async Task UpdateAsync(DepartamentoModel dept)
    {
        _context.Departamento.Update(dept);
        await _context.SaveChangesAsync();
    }

}

