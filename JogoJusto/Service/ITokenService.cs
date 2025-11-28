namespace JogoJusto.Service;

public interface ITokenService
{
    string CreateToken(int userId, string userName);
}
