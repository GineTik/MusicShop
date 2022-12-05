using AutoMapper;
using FluentValidation;
using MusicShop.Core.DTO;
using MusicShop.Core.DTO.Enums;
using MusicShop.Core.Entities;
using MusicShop.Core.Exceptions;
using MusicShop.DataAccess.Repository;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.EmailServices;
using MusicShop.Services.HasherServices;
using System.Collections.Generic;

namespace MusicShop.Services.AuthorizationServices
{
    public class UserService : IUserService
    {
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDTO> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUnitOfWork unitOfWork,
            IPasswordService passwordService, 
            ITokenService tokenService,
            IEmailService emailService,
            IMapper mapper,
            IValidator<UserDTO> validator)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _emailService = emailService;
            _mapper = mapper;
            _validator = validator;
        }

        private User AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            // важливо КОЛИ додаємо роль (до генерації JWT)
            user.Role = _unitOfWork.Roles.GetRoleUser();

            return _unitOfWork.Users.Add(user);
        }

        public UserDTO GetUser(int id)
        {
            return _mapper.Map<UserDTO>(_unitOfWork.Users.GetById(id));
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO> >(_unitOfWork.Users.GetAll());
        }

        public UserResponse TryLogin(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid == false)
                throw new ValidationException(result.Errors);

            var user = _unitOfWork.Users.GetByEmail(dto.Email);
            if (user == null)
                throw new AuthorizationException();

            if (_passwordService.VerifyHashedPassword(user.PasswordHash, dto) == false)
                throw new AuthorizationException();
                
            var token = _tokenService.BuildToken(user);
            
            return new UserResponse()
            { 
                Code = StatusCodes.Success,
                Token = token,
                Email = user.Email,
                Username = user.UserName,
            };
        }

        public UserResponse TryRegistration(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid == false)
                throw new ValidationException(result.Errors);

            var user = _unitOfWork.Users.GetByEmail(dto.Email);
            if (user != null)
                throw new RegistrationException();
            

            var addedUser = AddUser(dto);
            var token = _tokenService.BuildToken(addedUser);

            return new UserResponse()
            {
                Code = StatusCodes.Success,
                Token = token,
                Email = addedUser.Email,
                Username = addedUser.UserName
            };
        }

        public OrderDTO OrderMusic(UserDTO user, MusicDTO music)
        {
            throw new System.NotImplementedException();
        }

        public void CancleOrderMusic(UserDTO user, MusicDTO music)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAllOrders(UserDTO user)
        {
            throw new System.NotImplementedException();
        }
    }
}
