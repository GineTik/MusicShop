using AutoMapper;
using FluentValidation;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.Exceptions;
using MusicShop.Core.WebHost.DTO;
using MusicShop.DataAccess.Repository.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IValidator<UserDTO> _validator;

        public UserService(
            IUserRepository repository,
            IRoleRepository roleRepository,
            IPasswordService passwordService, 
            ITokenService tokenService, 
            IMapper mapper,
            IValidator<UserDTO> validator)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _mapper = mapper;
            _validator = validator;
        }

        public User AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            // важливо КОЛИ додаємо роль (до генерації JWT)
            user.Role = _roleRepository.GetRoleUser();
            return _repository.Add(user);
        }

        public User GetUser(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public string Login(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid == false)
                throw new ValidationException(result.Errors);

            var user = _repository.GetByEmail(dto.Email);
            if (user == null)
                throw new AuthorizationException();

            if (_passwordService.VerifyHashedPassword(user.PasswordHash, dto) == false)
                throw new AuthorizationException();
                
            var token = _tokenService.BuildToken(user);
            return token;
        }

        public string Registration(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid == false)
                throw new ValidationException(result.Errors);

            var user = _repository.GetByEmail(dto.Email);
            if (user != null)
                throw new RegistrationException();
            
            var addedUser = AddUser(dto);
            var token = _tokenService.BuildToken(addedUser);

            return token;
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
