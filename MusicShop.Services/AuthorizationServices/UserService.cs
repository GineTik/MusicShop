using Microsoft.Extensions.Configuration;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.WebHost.DTO;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.HasherServices;
using System.Collections.Generic;

namespace MusicShop.Services.AuthorizationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenServices _tokenService;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, IPasswordService passwordService, IConfiguration configuration, ITokenServices tokenService)
        {
            _repository = repository;
            _passwordService = passwordService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public User AddUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Email = userDTO.Email,
                UserName = userDTO.Username,
                PasswordHash = _passwordService.HashPassword(userDTO),
                EmailConfirmed = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };

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
            var user = _repository.GetByEmail(dto.Email);

            if (user == null)
                return UserResponse.NotAcceptable;

            var token = _tokenService.BuildToken(
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                user
            );

            if (_passwordService.VerifyHashedPassword(user.PasswordHash, dto))
                return UserResponse.Success(token);

            return UserResponse.NotAcceptable;
        }

        public UserResponse TryRegistration(UserDTO dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user != null)
                return UserResponse.NotAcceptable;
            
            var addedUser = AddUser(dto);
            // зарефакторити метод BuildToken
            var token = _tokenService.BuildToken(
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                addedUser
            );

            return UserResponse.Success(token);
        }
    }
}
