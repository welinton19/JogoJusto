
using JogoJusto.Models;
using JogoJusto.Pagination;

namespace JogoJusto.AppDta.Repository;

public interface IUsuarioRepository
{
    

    Task CriarUsuarioAsync( string email, string senha, string tipo);

    UsuarioModel? AutenticarUsuario(string email, string senha);


    Task<PagedResult<UsuarioModel>> GetUsuariosAsync(int pageNumber, int pageSize);
    bool Login(string email, string password);
}
