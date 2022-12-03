using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.Exceptions;
using MusicShop.DataAccess.Repository;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.AuthorizationServices;
using System;
using System.Collections.Generic;
using Xunit;

namespace MusicShop.Tests.UserTests
{
    public class UserService_Registration
    {
        private readonly Mock<IValidator<UserDTO>> _validatorMock;
        private readonly Mock<ITokenService> _tokenMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public UserService_Registration()
        {
            _validatorMock = new Mock<IValidator<UserDTO>>();
            _validatorMock
                .Setup(validator => validator.Validate(It.IsAny<UserDTO>()))
                .Returns(new ValidationResult() { Errors = new() });

            _tokenMock = new();
            _tokenMock
                .Setup(service => service.BuildToken(It.IsAny<User>()))
                .Returns("");

            _mapperMock = new();
            _mapperMock
               .Setup(mapper => mapper.Map<User>(It.IsAny<UserDTO>()))
               .Returns(new User());

            _unitOfWorkMock = new();
            _unitOfWorkMock
                .Setup(uow => uow.Roles.GetRoleUser())
                .Returns(new Role("User"));
            _unitOfWorkMock
                .Setup(uow => uow.Users.Add(It.IsAny<User>()))
                .Returns(new User());
        }

        public static IEnumerable<object[]> GetUsersForRegistration =>
            new List<object[]>
            {
                new object[] { new UserDTO() { Email = "email", Password = "a" } },
                new object[] { new UserDTO() { Email = "tydacyda", Password = "12353223" } },
                new object[] { new UserDTO() { Email = "email@gmail.com", Password = "a" } },
            };

        [Theory]
        [MemberData(nameof(GetUsersForRegistration))]
        public void Registration_UserDTO_ThrowException(UserDTO dto)
        {
            _unitOfWorkMock.Setup(uow => uow.Users.GetByEmail(It.IsAny<string>())).Returns(new User());

            var userService = new UserService(_unitOfWorkMock.Object, null, _tokenMock.Object, null, _mapperMock.Object, _validatorMock.Object);

            Assert.Throws<RegistrationException>(() =>
            {
                userService.TryRegistration(dto);
            });
        }

        [Theory]
        [MemberData(nameof(GetUsersForRegistration))]
        public void Registration_UserDTO_ReturnToken(UserDTO dto)
        {
            _unitOfWorkMock.Setup(uow => uow.Users.GetByEmail(It.IsAny<string>())).Returns(() => null);

            var userService = new UserService(_unitOfWorkMock.Object, null, _tokenMock.Object, null, _mapperMock.Object, _validatorMock.Object);
            var response = userService.TryRegistration(dto);

            Assert.NotNull(response);
        }
    }
}
