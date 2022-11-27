using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Services.HasherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.WebHost.MiddlewareComponents
{
    public class FirstInitDataMiddleware
    {

        private DataContext _db;
        
        private IMapper _mapper;

        private RequestDelegate _next;


        public FirstInitDataMiddleware(RequestDelegate next)
        {
            this._next = next;
         
        }


        private void init()
        {

            if (_db.Roles.Count() <= 0)
            {
                _db.Roles.Add(new Role("Admin"));
                _db.Roles.Add(new Role("Moder"));
                _db.Roles.Add(new Role("User"));
                _db.SaveChanges();
            }

            

            if (_db.Users.FirstOrDefault( u => u.Email == "admin@gmail.com") == null)
            {

                var user = _mapper.Map<User>(new UserDTO()
                {
                    Email = "admin@gmail.com",
                    Password = "string",
                    Username = "string"
                });

                user.Role = _db.Roles.First();
                _db.Users.Add(user);

                _db.SaveChanges();
            }

    
        }

        public async Task InvokeAsync(HttpContext context, DataContext dataContext, IMapper mapper)
        {
            this._mapper = mapper;
            this._db = dataContext;

            init();

            
            await _next.Invoke(context);
        }
    }
}
