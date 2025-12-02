using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace JogoJusto.Atributtes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;

    public RoleAuthorizeAttribute(string role)
    {
        _role = role;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity!.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult(); // 401
            return;
        }

        var role = user.FindFirst(ClaimTypes.Role)?.Value;

        if (role == null || !_role.Contains(role))
        {
            context.Result = new ForbidResult(); // 403
            return;
        }
    }
}
