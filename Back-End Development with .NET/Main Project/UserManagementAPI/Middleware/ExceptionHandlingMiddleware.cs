using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserManagementApi.Middleware
{
    /// <summary>
    /// Middleware to catch unhandled exceptions and return standardized JSON.
    /// Also logs the exception via Serilog.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call next middleware
                await _next(context);
            }
            catch (System.Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Unhandled exception occurred.");

                // Return standardized JSON response
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = "Internal server error",
                    detail = ex.Message // Optional: remove in production for security
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

    /// <summary>
    /// Extension method for cleaner registration in Program.cs
    /// </summary>
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
