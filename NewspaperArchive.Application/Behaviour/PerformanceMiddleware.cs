using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NewspaperArchive.Application.Behaviour
{
    public class PerformanceMiddleware
    {
        private readonly Stopwatch _timer;
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public PerformanceMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            _timer.Start();
            await _next(httpContext);
            _timer.Stop();
            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds > 500)
            {
                var requestName = httpContext.Request.Headers.GetType().Name;
                var request = httpContext.Request;

                _logger.LogWarning("CleanArchitecture Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName, elapsedMilliseconds, request);
            }

        }

    }
}
