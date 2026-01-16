namespace UserManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;
            
            _logger.LogInformation("Request: {Method} {Path} at {Time}", 
                context.Request.Method, 
                context.Request.Path, 
                startTime);

            await _next(context);

            var endTime = DateTime.UtcNow;
            var duration = endTime - startTime;

            _logger.LogInformation("Response: {StatusCode} for {Method} {Path} in {Duration}ms", 
                context.Response.StatusCode,
                context.Request.Method, 
                context.Request.Path, 
                duration.TotalMilliseconds);
        }
    }
}