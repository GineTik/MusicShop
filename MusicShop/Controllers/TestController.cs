using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicShop.Core.Entities;
using MusicShop.Services.EmailServices;
using MusicShop.Services.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public TestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("Hello ");
        }

        [Authorize]
        [HttpGet("ForAuthorizeUser")]
        public IActionResult ForAuthorizeUser()
        {
            return Ok("For authorize User");
        }


        [HttpGet("ForAdmins")]
        [Authorize(Roles = "Admin")]
        public IActionResult ForAdmin()
        {
            return Ok("You admin)))");
        }

        [HttpPost("confirm")]
        public IActionResult Confirm([FromForm] string token)
        {
            _ = HttpContext;

            return Ok(token);
        }

        
    }
}
