using JogoJusto.Models;

namespace JogoJusto.Middleware;

public class UsuarioMiddleware
{
    private RequestDelegate _requestDelegate;

    public UsuarioMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var user = new UsuarioModel
        {
            Id = 1,
            Email = "batistawelinton19@gmail.com",
            Password = "19202426",
            Tipo = "Admin"
        };
        context.Items["user"] = user;
        await _requestDelegate(context);
    }
}
