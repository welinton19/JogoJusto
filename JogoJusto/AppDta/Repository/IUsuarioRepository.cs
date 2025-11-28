namespace JogoJusto.AppDta.Repository;

public interface IUsuarioRepository
{
    void CriarUsuario( string email, string senha, string tipo);
    void Login(string email, string senha);
    //void Logout();
   
}
