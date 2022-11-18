using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.ProductServices;

namespace MusicShop.WebHost.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(MusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Add(MusicRequest request)
        {
            var dto = _mapper.Map<MusicDTO>(request);
            var music = _musicService.AddMusic(dto);

            return music == null ? BadRequest() : Ok(music);
        }
    }
}
