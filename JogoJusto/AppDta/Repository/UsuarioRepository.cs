using JogoJusto.Models;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly JogoJustoDbContext _jogoJustoDbContext;

    public UsuarioRepository(JogoJustoDbContext jogoJustoDbContext)
    {
        this._jogoJustoDbContext = jogoJustoDbContext;
    }

    public async Task CriarUsuarioAsync(string email, string senha, string tipo)
    {
       await _jogoJustoDbContext.Usuario.AddAsync(new UsuarioModel
        {
            Email = email,
            Password = senha,
            Tipo = tipo
        });

        await _jogoJustoDbContext.SaveChangesAsync();
    }

 
    public bool Login(string email, string senha)
    {
        var usuarioExistente = _jogoJustoDbContext.Usuario
            .FirstOrDefault(u => u.Email == email && u.Password == senha);
        return usuarioExistente != null;
    }


    public async Task<PagedResult<UsuarioModel>> GetUsuariosAsync(int pageNumber, int pageSize)
    {
        var query = _jogoJustoDbContext.Usuario
            .AsNoTracking()
            .OrderBy(u => u.Id)
            .AsQueryable();

        var total = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<UsuarioModel>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = total,
            Items = items
        };
    }
}
