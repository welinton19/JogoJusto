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

    

}
