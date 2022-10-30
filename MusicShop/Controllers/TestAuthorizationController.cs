using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Core.WebHost.DTO;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestAuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;

        public TestAuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
             
            
            return Ok();
        }

        [HttpPost("Signin")]
        public IActionResult Signin(UserRequest request)
        {
            var dto = new UserDTO()
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
            };

            var result = _userService.TryLogin(dto);
            return StatusCode((int)result.Code, result);
        }

        [HttpPost("Signup")]
        public IActionResult Signup(UserRequest request)
        {
            var dto = new UserDTO()
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
            };

            var result = _userService.TryRegistration(dto);
            return StatusCode((int)result.Code, result);
        }
    }
}
