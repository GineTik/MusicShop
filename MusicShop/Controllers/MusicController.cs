using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.Entities;
using MusicShop.Services.MusicServices;

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

        [HttpGet("getMusicsByCategoryId")]
        public IActionResult GetMusicsByCategoryId(int id)
        {
            return Ok(_musicService.GetMusicsByCategoryId(id));
        }
    }
}
