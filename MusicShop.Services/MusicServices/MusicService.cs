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

        public Music CreateMusic(MusicDTO dto)
        {
            var music = _mapper.Map<Music>(dto);
            // додати сповіщувач. Оповістити всіх юзерів.
            // Краще додати евент. Куди через паблік властивість додамо евенти 
            return _unitOfWork.Musics.Add(music);
        }

        public bool DeleteMusic(int musicId)
        {
            return _unitOfWork.Musics.Remove(musicId);
        }

        public IEnumerable<Music> GetMusicsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Music> GetMusicsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Music> GetMusicsByPriceRange(decimal from, decimal to)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersMusic(Music music)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersMusic(int musicId)
        {
            throw new NotImplementedException();
        }
        
        public void AssignDiscountCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void MusicDiscount(Music music)
        {
            throw new NotImplementedException();
        }

        public Music Update(MusicDTO dto)
        {
            throw new NotImplementedException();
        }

        public void SalesOnCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void SalesOnMusic(Music music)
        {
            throw new NotImplementedException();
        }
    }
}
