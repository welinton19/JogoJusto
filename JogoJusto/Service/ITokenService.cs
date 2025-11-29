using JogoJusto.Models;

namespace JogoJusto.Service;


public interface ITokenService
{
    
    string GenerateToken(UsuarioModel usuario);
}
