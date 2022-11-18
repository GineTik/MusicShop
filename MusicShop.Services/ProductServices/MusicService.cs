using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Implementations;
using MusicShop.Services.Validators;

namespace MusicShop.Services.ProductServices
{
    public class MusicService : IMusicService
    {
        private readonly MusicRepository _musicRepository;
        private readonly MusicDTOValidator _musicDTOValidator;
        private readonly IMapper _mapper;

        public MusicService(MusicRepository musicRepository, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        public Music AddMusic(MusicDTO dto)
        {
            var result = _musicDTOValidator.Validate(dto);

            if (result.IsValid == false)
                return null;

            var music = _mapper.Map<Music>(dto);
            _musicRepository.Add(music);
            return music;
        }
    }
}
