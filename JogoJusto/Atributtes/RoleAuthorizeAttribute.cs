using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace JogoJusto.Atributtes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _roles;

    public RoleAuthorizeAttribute(string roles)
    {
        _roles = roles.Split(',')
                      .Select(r => r.Trim().ToLower())
                      .ToArray();
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity!.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var roleClaim = user.Claims.FirstOrDefault(c =>
            c.Type.Equals("role", StringComparison.OrdinalIgnoreCase) ||
            c.Type.Equals(ClaimTypes.Role, StringComparison.OrdinalIgnoreCase)
        );

        if (roleClaim == null)
        {
            context.Result = new ForbidResult();
            return;
        }

        var userRole = roleClaim.Value.ToLower();

        if (!_roles.Contains(userRole))
        {
            context.Result = new ForbidResult();
            return;
        }
    }
}