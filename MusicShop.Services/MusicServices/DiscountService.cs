using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public Discount Create(DiscountDTO dto)
        {
            var discount = _mapper.Map<Discount>(dto);
            return _discountRepository.Add(discount);
        }

        public IEnumerable<Discount> GetAll()
        {
            return _discountRepository.GetAll();
        }

        public IEnumerable<Discount> GetAllAvailableDiscountOfUserForMusic(int userId, int musicId)
        {
            return _discountRepository.GetAllAvailableDiscountOfUserForMusic(userId, musicId);
        }

        public IEnumerable<Discount> GetAllByMusicId(int musicId)
        {
            return _discountRepository.GetAllByMusicId(musicId);
        }

        public IEnumerable<Discount> GetAllByUserId(int userId)
        {
            return _discountRepository.GetAllByUserId(userId);
        }

        public bool Remove(int id)
        {
            return _discountRepository.Remove(id);
        }
    }
}
