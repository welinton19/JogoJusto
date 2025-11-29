using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IUsuarioService
{
    Task CriarUsuario(string tipo, string email, string senha);
    bool AutenticarUsuario(string email, string senha);

    Task<PagedResult<UsuarioViewModel>> GetUsuariosAsync(int pageNumber, int pageSize);
}