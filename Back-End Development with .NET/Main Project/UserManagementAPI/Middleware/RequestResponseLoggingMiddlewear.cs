using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace UserManagementApi.Middleware
{
    /// <summary>
    /// Middleware to log incoming HTTP requests and outgoing responses
    /// using Serilog.
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log incoming request
            Log.Information("Incoming Request: {Method} {Path}", 
                context.Request.Method, 
                context.Request.Path);

            try
            {
                // Call the next middleware in the pipeline
                await _next(context);

                // Log outgoing response
                Log.Information("Outgoing Response: {Method} {Path} responded {StatusCode}", 
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode);
            }
            catch (Exception ex)
            {
                // Log the exception along with request details
                Log.Error(ex, "Exception occurred processing request {Method} {Path}", 
                    context.Request.Method, 
                    context.Request.Path);

                // Re-throw so global exception handler can process it
                throw;
            }
        }
    }

    /// <summary>
    /// Extension method to make middleware registration cleaner
    /// </summary>
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
