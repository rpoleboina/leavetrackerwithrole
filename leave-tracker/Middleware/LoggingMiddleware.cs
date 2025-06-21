using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace leave_tracker.Middleware
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
            var stopwatch = Stopwatch.StartNew();

            // Log request details
            _logger.LogInformation("Handling request: {method} {url}", context.Request.Method, context.Request.Path);

            await _next(context); // Call the next middleware

            stopwatch.Stop();

            // Log response details
            _logger.LogInformation("Finished handling request. Response status code: {statusCode} in {elapsedMilliseconds} ms", 
                context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
    }
}