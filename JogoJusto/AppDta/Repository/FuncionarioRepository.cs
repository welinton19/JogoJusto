using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta.Repository;

    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly JogoJustoDbContext _context;

        public FuncionarioRepository(JogoJustoDbContext context)
        {
            _context = context;
        }

        public async Task<FuncionarioModel?> GetByIdAsync(int id)
        {
            return await _context.Funcionario
                .Include(f => f.Departamento)
                .Include(f => f.Mentor)
                .FirstOrDefaultAsync(f => f.FuncionarioId == id);
        }

    public async Task<PagedResult<FuncionarioViewModel>> GetFuncionariosAsync(int pageNumber, int pageSize)
    {
        var query =
            from f in _context.Funcionario
            join d in _context.Departamento on f.DepartamentoId equals d.IdDepartamento into dept
            from d in dept.DefaultIfEmpty()
            join g in _context.Funcionario on d.GerenteId equals g.FuncionarioId into ger
            from g in ger.DefaultIfEmpty()
            join m in _context.Funcionario on f.MentorId equals m.FuncionarioId into mentor
            from m in mentor.DefaultIfEmpty()
            orderby f.FuncionarioId
            select new FuncionarioViewModel
            {
                FuncionarioId = f.FuncionarioId,
                Nome = f.Nome,
                Cargo = f.Cargo,

                DepartamentoId = d.IdDepartamento,
                DepartamentoNome = d.NomeDepartamento, 

                GerenteId = d.GerenteId,
                GerenteNome = g != null ? g.Nome : null,

                MentorId = f.MentorId,
                MentorNome = m != null ? m.Nome : null
            };

        var total = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<FuncionarioViewModel>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = total
        };
    }

    public async Task CreateAsync(FuncionarioModel funcionario)
        {
            await _context.Funcionario.AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FuncionarioModel funcionario)
        {

        _context.Funcionario.Attach(funcionario);

        _context.Entry(funcionario).Property(f => f.Nome).IsModified = true;
        _context.Entry(funcionario).Property(f => f.Genero).IsModified = true;
        _context.Entry(funcionario).Property(f => f.Cargo).IsModified = true;
        _context.Entry(funcionario).Property(f => f.Raca).IsModified = true;
        _context.Entry(funcionario).Property(f => f.StPcd).IsModified = true;
        _context.Entry(funcionario).Property(f => f.TipoPcd).IsModified = true;
        _context.Entry(funcionario).Property(f => f.Salario).IsModified = true;
        _context.Entry(funcionario).Property(f => f.DepartamentoId).IsModified = true;
        _context.Entry(funcionario).Property(f => f.MentorId).IsModified = true;
        _context.Entry(funcionario).Reference(f => f.Departamento).IsModified = false;
        _context.Entry(funcionario).Reference(f => f.Mentor).IsModified = false;

        await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var func = await GetByIdAsync(id);
            if (func != null)
            {
                _context.Funcionario.Remove(func);
                await _context.SaveChangesAsync();
            }
        }
    }

