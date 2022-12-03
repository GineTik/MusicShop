using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DiscountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Discount Create(DiscountDTO dto)
        {
            var discount = _mapper.Map<Discount>(dto);
            return _unitOfWork.Discounts.Add(discount);
        }

        public IEnumerable<Discount> GetAll()
        {
            return _unitOfWork.Discounts.GetAll();
        }

        public IEnumerable<Discount> GetAllAvailableDiscountOfUserForMusic(int userId, int musicId)
        {
            return _unitOfWork.Discounts.GetAllAvailableDiscountOfUserForMusic(userId, musicId);
        }

        public IEnumerable<Discount> GetAllByMusicId(int musicId)
        {
            return _unitOfWork.Discounts.GetAllByMusicId(musicId);
        }

        public IEnumerable<Discount> GetAllByUserId(int userId)
        {
            return _unitOfWork.Discounts.GetAllByUserId(userId);
        }

        public bool Remove(int id)
        {
            return _unitOfWork.Discounts.Remove(id);
        }
    }
}
