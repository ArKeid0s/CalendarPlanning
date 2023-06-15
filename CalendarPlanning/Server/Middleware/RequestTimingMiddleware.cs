using System.Diagnostics;

namespace CalendarPlanning.Server.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = new Stopwatch();

            try
            {
                sw.Start();
                await _next(context);
            }
            finally
            {
                sw.Stop();
                _logger.LogInformation(
                    "Request {Method} {Path} executed in {ElapsedMilliseconds}ms",
                    context.Request.Method, context.Request.Path, sw.ElapsedMilliseconds);
            }



        }
    }
}
