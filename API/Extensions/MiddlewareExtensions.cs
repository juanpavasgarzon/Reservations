using API.Middleware;

namespace API.Extensions;

public static class MiddlewareExtensions
{
    public static void UseRequestContextLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextLoggingMiddleware>();
    }
}