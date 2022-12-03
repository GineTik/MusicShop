using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MusicShop.WebHost.Filters.ExceptionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ValidationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException exception)
            {
                var response = new
                {
                    Code = 400,
                    Errors = exception.Errors
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = 400
                };
            }
        }
    }
}