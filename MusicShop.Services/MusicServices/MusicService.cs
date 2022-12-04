using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository;
using System;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public class MusicService : IMusicService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MusicService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public MusicDTO CreateMusic(MusicDTO dto)
        {
            // додати сповіщувач. Оповістити всіх юзерів.
            // Краще додати евент. Куди через паблік властивість додамо евенти 
            var music = _mapper.Map<Music>(dto);
            var result = _unitOfWork.Musics.Add(music);

            return _mapper.Map<MusicDTO>(result);
        }

        public bool DeleteMusic(int musicId)
        {
            return _unitOfWork.Musics.Remove(musicId);
        }

        public IEnumerable<MusicDTO> GetMusicsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MusicDTO> GetMusicsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MusicDTO> GetMusicsByPriceRange(decimal from, decimal to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetOrdersMusic(MusicDTO music)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetOrdersMusic(int musicId)
        {
            throw new NotImplementedException();
        }
        
        public void AssignDiscountCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public void MusicDiscount(MusicDTO music)
        {
            throw new NotImplementedException();
        }

        public MusicDTO Update(MusicDTO dto)
        {
            throw new NotImplementedException();
        }

        public void SalesOnCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public void SalesOnMusic(MusicDTO music)
        {
            throw new NotImplementedException();
        }
    }
}
