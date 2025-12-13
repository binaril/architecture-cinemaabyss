using System.Text.Json;
using events.Models;

namespace events.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware> logger)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message + "\n" + ex.InnerException?.Message);
            logger.LogError("Error query: {query}", context.Request.Path);
            logger.LogDebug(ex.StackTrace);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "text/plain";

            var result = new Error
            {
                error = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}