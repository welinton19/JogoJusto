namespace JogoJusto.AppDta.Repository;

public class TokenRepository : ITokenRepository
{
    private readonly JogoJustoDbContext _jogoJustoDbContext;

    public TokenRepository(JogoJustoDbContext jogoJustoDbContext)
    {
        _jogoJustoDbContext = jogoJustoDbContext;
    }

    public string GerarToken()
    {
        _jogoJustoDbContext.Tokem.Add(new Models.TokenModel
        {
            Token = Guid.NewGuid().ToString(),
            Expiration = DateTime.UtcNow.AddHours(1)
        });
        _jogoJustoDbContext.SaveChanges();
        return _jogoJustoDbContext.Tokem
            .OrderByDescending(t => t.Expiration)
            .First().Token!;
    }
}
