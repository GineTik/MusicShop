using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;

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

        public DiscountDTO Create(DiscountDTO dto)
        {
            var discount = _mapper.Map<Discount>(dto);
            return _mapper.Map<DiscountDTO>(_unitOfWork.Discounts.Add(discount));
        }

        public IEnumerable<DiscountDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<DiscountDTO>>(_unitOfWork.Discounts.GetAll());
        }

        public IEnumerable<DiscountDTO> GetAllAvailableDiscountOfUserForMusic(UserDTO user, MusicDTO music)
        {
            return _mapper.Map<IEnumerable<DiscountDTO>>( 
                _unitOfWork.Discounts.GetAllAvailableDiscountOfUserForMusic(user.Id, music.Id)
                );
        }

        public IEnumerable<DiscountDTO> GetAllByMusicId(MusicDTO music)
        {
            return _mapper.Map<IEnumerable<DiscountDTO>>(
                _unitOfWork.Discounts.GetAllByMusicId(music.Id)
                );
        }

        public IEnumerable<DiscountDTO> GetAllByUser(UserDTO user)
        {
            return _mapper.Map<IEnumerable<DiscountDTO>>(
                _unitOfWork.Discounts.GetAllByUserId(user.Id)
                ); 
        }

        public bool AttachUserToDiscount(int userId, int discountId)
        {
            return _unitOfWork.Discounts.AttachUserToDiscount(userId, discountId);
        }

        public bool AttachMusicToDiscount(int musicId, int discountId)
        {
            return _unitOfWork.Discounts.AttachMusicToDiscount(musicId, discountId);
        }

        public bool Remove(DiscountDTO discount)
        {
            return _unitOfWork.Discounts.Remove(discount.Id);
        }
    }
}
