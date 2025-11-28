using JogoJusto.AppDta;

namespace JogoJusto.Service;

public class UsuarioService : IUsuarioService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public UsuarioService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public bool AutenticarUsuario(string email, string senha)
    {
        var usuarioExistente = _jogodbcontext.Usuario
             .FirstOrDefault(u => u.Email == email && u.Password == senha);
        return usuarioExistente != null;
    }

    public void CriarUsuario(string tipo, string email, string senha)
    {
        var novoUsuario = new Models.UsuarioModel
        {
            Tipo = tipo,
            Email = email,
            Password = senha
        };
    }
}