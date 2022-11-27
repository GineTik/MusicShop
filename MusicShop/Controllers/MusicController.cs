using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.Entities;
using MusicShop.Services.MusicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        


        [HttpGet("getMusicsByCategory")]
        public IActionResult GetMusicsByCategory(Category category)
        {
            return Ok(_musicService.GetMusicsByCategory(category));
        }
    }
}
