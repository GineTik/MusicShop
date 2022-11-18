using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Implementations;

namespace MusicShop.Services.ProductServices
{
    public class MusicService
    {
        private readonly MusicRepository _musicRepository;
        private readonly IMapper _mapper;

        public MusicService(MusicRepository musicRepository, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        public void AddMusic(MusicDTO dto)
        {
            var music = _mapper.Map<Music>(dto);
            _musicRepository.Add(music);
        }
    }
}
