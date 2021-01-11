using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewspaperArchive.Application.Behaviour
{
   public class ExceptionMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(ILogger logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, CancellationToken cancellationToken)
        {
            try
            {              
                await _next(httpContext);
            }
            catch (Exception ex)
            {  
                await HandleException(httpContext.Response,_logger, ex);
                throw;
            }

        }
        private static async Task HandleException(HttpResponse httpResponse, ILogger _logger, Exception exception)
        {
            httpResponse.Headers.Add("Exception-Type", exception.GetType().Name);
            
            await httpResponse.WriteAsync(exception.Message).ConfigureAwait(false);

        }
    }

}
