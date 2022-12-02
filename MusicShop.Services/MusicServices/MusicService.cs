using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.MusicServices
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;

        public MusicService(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public bool Buy(int musicId, List<int> discountsIds)
        {
            throw new NotImplementedException();
        }

        public Music CreateMusic(Music music)
        {

            // додати сповіщувач. Оповістити всіх юзерів.
            // Краще додати евент. Куди через паблік властивість додамо евенти 
            return _musicRepository.Add(music);
        }

        public bool DeleteMusic(int musicId)
        {
            return _musicRepository.Remove(musicId);
        }

        public IEnumerable<Music> GetMusicsByCategory(Category category)
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

        public Music Update(Music music)
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
