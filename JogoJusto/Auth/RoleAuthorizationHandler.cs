using JogoJusto.Auth;
using Microsoft.AspNetCore.Authorization;

public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        RoleRequirement requirement)
    {
        var role = context.User.FindFirst("role")?.Value;

        if (role == requirement.Role)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

