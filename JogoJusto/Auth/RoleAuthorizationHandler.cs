
namespace JogoJusto.Auth;

public class RoleAuthorizationHandler : IAuthorizationHandler
{
    //private readonly ITokenService _tokenService;
    public Task<bool> AuthorizeAsync(string userId, string requiredRole)
    {
        throw new NotImplementedException();
    }
}
