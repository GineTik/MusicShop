using AutoMapper;
using FluentValidation.Results;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.Validators;
using System;
using System.Linq;

namespace MusicShop.Services.ProductServices
{
    public class MusicService : IMusicService
    {
        private readonly MusicDTOValidator _musicDTOValidator;
        private readonly IMusicRepository _musicRepository;
        private readonly IMapper _mapper;

        public MusicService(MusicDTOValidator musicDTOValidator, IMusicRepository musicRepository, IMapper mapper)
        {
            _musicDTOValidator = musicDTOValidator;
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        public Music AddMusic(MusicDTO dto)
        {
            ValidationResult result = _musicDTOValidator.Validate(dto);

            if (result.IsValid == false)
                throw new InvalidOperationException($"{result.Errors.First().PropertyName}, {result.Errors.First().ErrorCode}");

            var music = _mapper.Map<Music>(dto);
            _musicRepository.Add(music);
            return music;
        }
    }
}
