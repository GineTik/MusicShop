using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Services.RoleServices;
using System;

namespace MusicShop.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("Add")]
        public IActionResult Add(RoleDTO role)
        {
            throw new NotImplementedException();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("GetUsersByRole/{name}")]
        public IActionResult GetUsersByRole(string name)
        {
            throw new NotImplementedException();
            //json exception
            //return Ok(_roleService.GetUsersByRoleName(name));
        }

        [HttpGet]
        [Route("GetRoleByUserEmail/{email}")]
        public IActionResult GetRoleByUserEmail(string email)
        {
            throw new NotImplementedException();
            //json exception
            //return Ok(_roleService.GetRoleByUserEmail(email));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("GiveModer")]
        public IActionResult GiveRoleUser(int userId)
        {
            throw new NotImplementedException();
            //json exception
            //return Ok(_roleService.AssignModerRoleToUser(userId));
        }
    }
}