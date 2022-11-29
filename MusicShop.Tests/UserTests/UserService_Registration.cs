using FluentValidation;
using FluentValidation.Results;
using Moq;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
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
        private readonly Mock<IUserRepository> _repositoryMock;

        public UserService_Registration()
        {
            _validatorMock = new Mock<IValidator<UserDTO>>();
            _validatorMock
                .Setup(validator => validator.Validate(It.IsAny<UserDTO>()))
                .Returns(new ValidationResult() { Errors = new() });

            _repositoryMock = new Mock<IUserRepository>();
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
            _repositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<string>())).Returns(() => null);

            var userService = new UserService(_repositoryMock.Object, null, null, null, null, _validatorMock.Object);

            Assert.Throws<Exception>(() =>
            {
                userService.TryRegistration(dto);
            });
        }

        [Theory]
        [MemberData(nameof(GetUsersForRegistration))]
        public void Registration_UserDTO_ReturnToken(UserDTO dto)
        {
            _repositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<string>())).Returns(new User());

            var userService = new UserService(_repositoryMock.Object, null, null, null, null, _validatorMock.Object);
            var token = userService.TryRegistration(dto);

            Assert.NotNull(token);
        }
    }
}
