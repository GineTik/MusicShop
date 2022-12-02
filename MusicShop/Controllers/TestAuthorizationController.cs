using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Core.WebHost.DTO;
using Microsoft.Extensions.Configuration;
using System.Net;
using AutoMapper;
using System;
using System.Security.Claims;
using MusicShop.Services.EmailServices;
using MusicShop.Services.Utils;
using MusicShop.Core.Entities;
using System.IO;
using MusicShop.Core.DTO.Enums;
using MusicShop.WebHost.Filters.ExceptionFilters;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestAuthorizationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        //private readonly HtmlContent _htmlContent;
        public TestAuthorizationController(IUserService userService, IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _userService = userService;
            _mapper = mapper;

            //_htmlContent = new HtmlContent();
        }

        [HttpPost("signin")]
        [AuthorizationExceptionFilter]
        [ValidationExceptionFilter]
        public IActionResult Signin(UserRequest request)
        {
            var dto = _mapper.Map<UserDTO>(request);
            var token = _userService.Login(dto);

            this.HttpContext.Response.Cookies.Append("Token", token,
                new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    MaxAge = TimeSpan.MaxValue,
                    Expires = DateTime.UtcNow.AddDays(30)
                });

            return Ok(new UserResponse(StatusCodes.Success)
            {
                Email = request.Email,
                Username = request.Username,
                Token = token,
            });
        }

        [HttpPost("signup")]
        [AuthorizationExceptionFilter]
        [ValidationExceptionFilter]
        public IActionResult Signup(UserRequest request)
        {
            var dto = _mapper.Map<UserDTO>(request);
            var result = _userService.TryRegistration(dto);

            _emailService.ConfirmEmail(result, @"HtmlTemplates/gmailConfirme.html", "Comfirm");
            
            return StatusCode((int)result.Code, result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("myRole")]
        public IActionResult GetMyRole()
        {
            var roleClaim = this.User.FindFirst(ClaimTypes.Role);

            if(roleClaim != null)
                return Ok(roleClaim.Value);
            return Ok("https://www.youtube.com/watch?v=Vew1_5oRp8s");
        }
 
        

    }
}
