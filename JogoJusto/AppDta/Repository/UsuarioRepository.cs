namespace JogoJusto.AppDta.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly JogoJustoDbContext _jogoJustoDbContext;

    public UsuarioRepository(JogoJustoDbContext jogoJustoDbContext)
    {
        this._jogoJustoDbContext = jogoJustoDbContext;
    }

    void IUsuarioRepository.CriarUsuario(string email, string senha, string tipo)
    {
       _jogoJustoDbContext.Usuario.Add(new Models.UsuarioModel
       {
           Email = email,
           Password = senha,
           Tipo = tipo
       });
    }

    void IUsuarioRepository.Login(string email, string senha)
    {
        _jogoJustoDbContext.Usuario.FirstOrDefault(u => u.Email == email && u.Password == senha);
    }
}
