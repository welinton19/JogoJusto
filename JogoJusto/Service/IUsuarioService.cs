namespace JogoJusto.Service;

public interface IUsuarioService
{
    void CriarUsuario(string tipo, string email, string senha);
    bool AutenticarUsuario(string email, string senha);


}