using JogoJusto.Models;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IUsuarioService
{
    object AutenticarUsuario(string email, string password);
    Task CriarUsuario(string tipo, string email, string senha);
    
    
    Task<PagedResult<UsuarioViewModel>> GetUsuariosAsync(int pageNumber, int pageSize);
}