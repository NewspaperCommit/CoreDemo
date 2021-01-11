using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace NewspaperArchive.Application.Behaviour
{
    //class Performance
    //{
    //}
    public class LoggingMiddleware
    {

        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            var requestName = httpContext.Request.Headers.GetType().Name;
            var request = httpContext.Request;

            _logger.LogInformation("Application Start");

            await _next(httpContext);

            _logger.LogInformation("CleanArchitecture Request: {Name} {@Request}",
               requestName, request);
        }


    }
}
