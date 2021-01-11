using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewspaperArchive.Application.Common.API.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewspaperArchive.Application.Common.API.Extensions
{
    public static class ModelStateExtension
    {
        public static IEnumerable<ValidationError> AllErrors(this ModelStateDictionary modelState)
        {
            return modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage))).ToList();
        }
    }
}
