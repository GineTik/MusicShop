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



    }
}
