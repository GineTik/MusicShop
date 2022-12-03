using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicShop.Core.DTO.Enums;
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
                var response = new 
                {
                    Code = StatusCodes.NotAcceptable,
                    Message = context.Exception.Message
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)StatusCodes.NotAcceptable
                };
            }
        }
    }
}