using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.AuthorizationServices;
using AutoMapper;
using System;
using System.Security.Claims;
using MusicShop.Services.EmailServices;
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

        public TestAuthorizationController(IUserService userService, IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("signin")]
        [AuthorizationExceptionFilter]
        [ValidationExceptionFilter]
        public IActionResult Signin(UserRequest request)
        {
            var dto = _mapper.Map<UserDTO>(request);
            var response = _userService.TryLogin(dto);

            HttpContext.Response.Cookies.Append("Token", response.Token,
                new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    MaxAge = TimeSpan.MaxValue,
                    Expires = DateTime.UtcNow.AddDays(30)
                });

            return Ok(response);
        }

        [HttpPost("signup")]
        [AuthorizationExceptionFilter]
        [ValidationExceptionFilter]
        public IActionResult Signup(UserRequest request)
        {
            var dto = _mapper.Map<UserDTO>(request);
            var response = _userService.TryRegistration(dto);

            _emailService.ConfirmEmail(response, @"HtmlTemplates/gmailConfirme.html", "Comfirm");
            
            return Ok(response);
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
