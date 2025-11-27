namespace JogoJusto.Auth;

public interface IAuthorizationHandler
{
    Task<bool> AuthorizeAsync(string userId, string requiredRole);
}
