using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Implementations;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Services.CategoryServices;
using MusicShop.Services.EmailServices;
using MusicShop.Services.HasherServices;
using MusicShop.Services.MusicServices;
using MusicShop.Services.Utils;
using MusicShop.Services.Validators;
using MusicShop.WebHost.AutoMapper.Profiles;
using MusicShop.WebHost.MiddlewareComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
         
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<DataContext>(op => 
                op.UseSqlServer(Configuration.GetConnectionString("cs1"))
            );
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicShop", Version = "v1" });
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IMusicRepository, MusicRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMusicService, MusicService>();

            services.AddTransient<IUserService, UserService>();
            

            var descriptor = new ServiceDescriptor(typeof(EmailSender),
                    _ => new EmailSender(Configuration["Google:accountForSMTP:Email"], Configuration["Google:accountForSMTP:Password"], "MusicShop"),
                    ServiceLifetime.Transient);
            services.Add(descriptor);
            services.AddTransient<IEmailService, EmailService>( );
            
            


            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme ).AddJwtBearer(op =>
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                }
            );

            // adding automappers profiles for DI
            services.AddAutoMapper(typeof(UserProfile));

            // adding validators
            services.AddValidatorsFromAssemblyContaining<UserDTOValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicShop v1"));
            }

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["Token"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();

            });



            app.UseRouting();


            app.UseMiddleware<FirstInitDataMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
