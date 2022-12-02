using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicShop.Core.Exceptions;
using System;

namespace MusicShop.WebHost.Filters.ExceptionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is AuthorizationException ||
                context.Exception is RegistrationException)
            {
                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = 406
                };
            }
        }
    }
}