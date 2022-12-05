using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
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

        #region CRUD

        [HttpGet("getMusicsByCategoryId")]
        public IActionResult GetMusicsByCategoryId(int id)
        {
            return Ok(_musicService.GetMusicsByCategoryId(id));
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_musicService.GetAll());
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] MusicDTO music)
        {
            return Ok(_musicService.CreateMusic(music));
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] MusicDTO music)
        {
            return Ok(_musicService.Update(music));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_musicService.DeleteMusic(id));
        }
        #endregion
    }
}
