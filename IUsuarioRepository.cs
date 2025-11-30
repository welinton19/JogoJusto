JogoJusto\AppDta\Repository\IUsuarioRepository.cs
using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IUsuarioRepository
{
    Task CriarUsuarioAsync( string email, string senha, string tipo);
    bool Login(string email, string senha);
    
    Task<PagedResult<UsuarioModel>> GetUsuariosAsync(int pageNumber, int pageSize);

    Task<UsuarioModel?> GetByEmailAsync(string email);
}