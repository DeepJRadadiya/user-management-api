using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UserManagementApi.Middleware
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
            // Log the request method and path
            _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
