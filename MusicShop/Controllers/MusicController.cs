using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.ProductServices;
using System;

namespace MusicShop.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : Controller
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(MusicDTO dto)
        {
            try
            {
                var music = _musicService.AddMusic(dto);
                return Ok(new { Code = 200, Music = music });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Code = 400, Message = ex.Message });
            }

            //var (result, music) = _musicService.AddMusic(dto);
            //return Json(new
            //{
            //    Code = result.IsValid ? 200 : 400,
            //    ValidationResult = result,
            //    Music = music
            //});
        }
    }
}
