using Microsoft.AspNetCore.Authorization;

namespace JogoJusto.Auth;

public class RoleRequirement : IAuthorizationRequirement
{
    public string[] Roles { get; }

    public RoleRequirement(string roles)
    {
        Roles = roles.Split(",")
                     .Select(r => r.Trim())
                     .Where(r => !string.IsNullOrWhiteSpace(r))
                     .ToArray();
    }
}
