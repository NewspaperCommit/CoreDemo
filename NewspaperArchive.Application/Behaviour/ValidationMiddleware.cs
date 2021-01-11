using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = NewspaperArchive.Application.Common.Exceptions.ValidationException;

namespace NewspaperArchive.Application.Behaviour
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<IValidator> _validators;
        public ValidationMiddleware(RequestDelegate next, IEnumerable<IValidator> validators)
        {
            _next = next;
            _validators = validators;
        }

        public async Task Invoke(HttpContext httpContext, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<HttpContext>(httpContext);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);                
            }
            await _next(httpContext);

        }
        }
    }
