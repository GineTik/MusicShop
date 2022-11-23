using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Core.WebHost.DTO;
using Microsoft.Extensions.Configuration;
using System.Net;
using AutoMapper;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestAuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TestAuthorizationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpPost("Signin")]
        public IActionResult Signin(UserRequest request)
        {
            var dto = _mapper.Map<UserDTO>(request);
            
            var result = _userService.TryLogin(dto);
            return StatusCode((int)result.Code, result);
        }

        [HttpPost("Signup")]
        public IActionResult Signup(UserRequest request)
        {
            var dto = _mapper.Map<UserDTO>(request);

            var result = _userService.TryRegistration(dto);
            return StatusCode((int)result.Code, result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}
