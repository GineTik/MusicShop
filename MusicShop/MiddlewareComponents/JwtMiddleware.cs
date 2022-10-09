using Microsoft.AspNetCore.Http;
using MusicShop.Services.AuthorizationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.WebHost.MiddlewareComponents
{
    public class JwtMiddleware
    {
        public async Task InvokeAsync(HttpContext context, IUserService userService)
        {
            throw new NotImplementedException();
        }
    }
}
