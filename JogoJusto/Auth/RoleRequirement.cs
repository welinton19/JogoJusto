using Microsoft.AspNetCore.Authorization;

namespace JogoJusto.Auth;

public class RoleRequirement : IAuthorizationRequirement
{
    public string Role { get; }
    public RoleRequirement(string role)
    {
        Role = role;
    }
}
