using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.HasherServices;
using System.Collections.Generic;

namespace MusicShop.Services.AuthorizationServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IPasswordService _passwordService;

        public UserService(IRepository<User> repository, IPasswordService passwordService)
        {
            _repository = repository;
            _passwordService = passwordService;
        }

        public void AddUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Email = userDTO.Email,
                UserName = userDTO.Username,
                PasswordHash = _passwordService.HashPassword(userDTO.Password, userDTO),
            };

            _repository.Add(user);
        }

        public User GetUser(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
