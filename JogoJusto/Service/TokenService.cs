using JogoJusto.AppDta;

namespace JogoJusto.Service;

public class TokenService : ITokenService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public TokenService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public string CreateToken(int userId, string userName)
    {
        var token = $"{userId}-{userName}-{Guid.NewGuid()}";
        return token;
    }
}
