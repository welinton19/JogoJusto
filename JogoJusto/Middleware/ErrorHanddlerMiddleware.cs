namespace JogoJusto.Middleware;

public class ErrorHanddlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHanddlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var response = new { message = "An unexpected error occurred.", details = ex.Message };
            await context.Response.WriteAsJsonAsync(response);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        var response = new { message = "An unexpected error occurred.", details = exception.Message };
        return context.Response.WriteAsJsonAsync(response);
    }

}
