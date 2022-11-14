using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            var a = this.User;
            
            return Ok("Hello ");
        }

        [HttpGet("Test2")]
        public IActionResult Test2()
        {
            return Ok("Hello 2");
        }


        [HttpGet("GetRoles")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRoles()
        {
            return Ok("Roles list");
        }


        [HttpGet("About")]
        public IActionResult About()
        {
            
            
            return Ok(User.FindFirst("Id").Value);
            
        }
    }
}
