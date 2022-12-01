using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using MusicShop.Core.DTO;
using MusicShop.Core.DTO.Enums;
using MusicShop.Core.Entities;
using MusicShop.Core.WebHost.DTO;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.EmailServices;
using MusicShop.Services.HasherServices;
using System.Collections.Generic;

namespace MusicShop.Services.AuthorizationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        //private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDTO> _validator;

        public UserService(
            IUserRepository repository,
            IRoleRepository roleRepository,
            IPasswordService passwordService, 
            IConfiguration configuration, 
            ITokenService tokenService,
            //IEmailService emailService,
            IMapper mapper,
            IValidator<UserDTO> validator)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _passwordService = passwordService;
            _configuration = configuration;
            _tokenService = tokenService;
            //_emailService = emailService;


            _mapper = mapper;
            _validator = validator;
        }

        public User AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            // важливо КОЛИ додаємо роль (до генерації JWT)
            user.Role = _roleRepository.GetRoleUser();
            _repository.Add(user);

            return user; // можуть бути колізії
        }

        public User GetUser(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public UserResponse TryLogin(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid == false)
                return UserResponse.ValidationFailed;

            var user = _repository.GetByEmail(dto.Email);
            if (user == null)
                return UserResponse.AuthorizationFailed;

            if (_passwordService.VerifyHashedPassword(user.PasswordHash, dto) == false)
                return UserResponse.AuthorizationFailed;
                
            var token = _tokenService.BuildToken(user);
            return UserResponse.Success(token);
        }

        public UserResponse TryRegistration(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid == false)
                return UserResponse.ValidationFailed;

            var user = _repository.GetByEmail(dto.Email);
            if (user != null)
                return UserResponse.AuthorizationFailed;
            
            var addedUser = AddUser(dto);
            var token = _tokenService.BuildToken(addedUser);

            //return UserResponse.Success(token);
            return new UserResponse()
            {
                Code = StatusCodes.Success,
                Email = addedUser.Email,
                Token = token,
                Username = addedUser.UserName
            };
        }

        public Order OrderMusic(User user, Music music)
        {
            throw new System.NotImplementedException();
        }

        public void CancleOrderMusic(User user, Music music)
        {
            throw new System.NotImplementedException();
        }

        public void GetAllOrders(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
