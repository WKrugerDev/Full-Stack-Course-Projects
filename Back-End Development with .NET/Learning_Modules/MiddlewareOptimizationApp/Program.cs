using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on HTTP only for simplicity
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5211); // Change port as needed
});

var app = builder.Build();

#region Logging Middleware
// Middleware to log any response with status >= 400
// Helps track security events and blocked requests
app.Use(async (context, next) =>
{
    await next(); // Run downstream middleware first

    if (context.Response.StatusCode >= 400)
    {
        Console.WriteLine($"Security Event: {context.Request.Path} - Status Code: {context.Response.StatusCode}");
    }
});
#endregion

#region Simulated HTTPS Enforcement
// Middleware to simulate HTTPS enforcement
// Blocks requests without "?secure=true" query parameter
app.Use(async (context, next) =>
{
    if (context.Request.Query["secure"] != "true")
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("Simulated HTTPS Required");
        return;
    }

    await next();
});
#endregion

#region Input Validation Middleware
// Middleware to validate query input and block unsafe characters
app.Use(async (context, next) =>
{
    var input = context.Request.Query["input"];
    if (!IsValidInput(input))
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid Input");
        }
        return;
    }

    await next();
});

// Helper function for input validation
static bool IsValidInput(string input)
{
    // Allow empty or alphanumeric input, block "<script>" patterns
    return string.IsNullOrEmpty(input) || (input.All(char.IsLetterOrDigit) && !input.Contains("<script>"));
}
#endregion

#region Lab Unauthorized Path Middleware
// Middleware to short-circuit requests to /unauthorized path
// Returns 401 Unauthorized for this specific path
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/unauthorized")
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized Access");
        }
        return; // Short-circuit pipeline
    }

    await next();
});
#endregion

#region Lab Query Parameter Authentication
// Middleware to simulate authentication using query parameter "?authenticated=true"
// Returns 403 Forbidden if not authenticated and sets a secure cookie if successful
app.Use(async (context, next) =>
{
    var isAuthenticated = context.Request.Query["authenticated"] == "true";
    if (!isAuthenticated)
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Access Denied");
        }
        return;
    }

    // Set a secure, HTTP-only cookie to demonstrate secure authentication
    context.Response.Cookies.Append("SecureCookie", "SecureData", new CookieOptions
    {
        HttpOnly = true,
        Secure = true
    });

    await next();
});
#endregion

#region Realistic Header-Based Authentication
// Middleware to simulate realistic header-based authentication
// Checks for X-Auth-Token header and blocks if missing or invalid
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.ContainsKey("X-Auth-Token") ||
        context.Request.Headers["X-Auth-Token"] != "secret-token")
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Realistic Authentication Failed: X-Auth-Token missing or invalid");
        }
        return; // Short-circuit
    }

    await next();
});
#endregion

#region Async Middleware
// Middleware to simulate asynchronous processing (e.g., I/O operations)
// Waits for downstream middleware and then performs async delay
app.Use(async (context, next) =>
{
    await next(); // Wait for downstream middleware
    await Task.Delay(100); // Simulate async operation

    if (!context.Response.HasStarted)
    {
        await context.Response.WriteAsync("Processed Asynchronously\n");
    }
});
#endregion

#region Final Response Middleware
// Final middleware to send a default response if nothing else has written
app.Run(async (context) =>
{
    if (!context.Response.HasStarted)
    {
        await context.Response.WriteAsync("Final Response from Application\n");
    }
});
#endregion

app.Run();