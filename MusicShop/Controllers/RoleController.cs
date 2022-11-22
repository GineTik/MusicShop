using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        [HttpPost("Add")]
        public IActionResult Add(Role role)
        {
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_roleRepository.GetAll());
        }

        [HttpGet]
        [Route("GetUsersByRole/{name}")]
        public IActionResult GetUsersByRole(string name)
        {
            return Ok(name);
        }

    }
}
