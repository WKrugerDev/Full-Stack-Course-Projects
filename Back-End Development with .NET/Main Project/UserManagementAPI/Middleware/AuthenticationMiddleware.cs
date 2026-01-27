using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Serilog;

namespace UserManagementApi.Middleware
{
    /// <summary>
    /// Middleware to validate token-based authentication.
    /// Returns 401 Unauthorized if the token is missing or invalid.
    /// </summary>
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
    {
        // Simple token validation
        if (!context.Request.Headers.TryGetValue("Authorization", out var token) ||
            string.IsNullOrWhiteSpace(token) ||
            token != "Bearer mysecrettoken") 
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = "Unauthorized" });
            return;
        }

        // Call next middleware
        await _next(context);
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Exception in AuthenticationMiddleware for request {Method} {Path}",
            context.Request.Method, context.Request.Path);
        throw; // let global exception handler take over
    }
        }
    }

    /// <summary>
    /// Extension method to simplify registration in Program.cs
    /// </summary>
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
