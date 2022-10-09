using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.Entities;
using MusicShop.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestAuthorizationController : ControllerBase
    {

        [HttpGet("Test")]
        public IActionResult Test()
        {
             
            
            return Ok();
        }

        [HttpPost("Signin")]
        public IActionResult Signin(UserRequest userRequest)
        {
            return Ok();
        }

        [HttpPost("Signup")]
        public IActionResult Signup()
        {
            return Ok();
        }
    }
}
