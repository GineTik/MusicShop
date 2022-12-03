using FluentValidation;
using FluentValidation.Results;
using Moq;
using MusicShop.Core.DTO;
using MusicShop.Core.DTO.Enums;
using MusicShop.Core.Entities;
using MusicShop.Core.Exceptions;
using MusicShop.DataAccess.Repository;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Services.HasherServices;
using System.Collections.Generic;
using Xunit;

namespace MusicShop.Tests.UserTests
{
    public class UserService_Login
    {
        private readonly Mock<IValidator<UserDTO>> _validatorMock;
        private readonly Mock<IPasswordService> _passwordValidatorMock;
        private readonly Mock<ITokenService> _tokenMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public UserService_Login()
        {
            _validatorMock = new();
            _validatorMock
                .Setup(validator => validator.Validate(It.IsAny<UserDTO>()))
                .Returns(new ValidationResult() { Errors = new() });

            _passwordValidatorMock = new();
            _passwordValidatorMock
                .Setup(validator => validator.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<UserDTO>()))
                .Returns(true);

            _tokenMock = new();
            _tokenMock
                .Setup(service => service.BuildToken(It.IsAny<User>()))
                .Returns("");

            _unitOfWorkMock = new();
        }

        public static IEnumerable<object[]> GetUsersForLogin =>
            new List<object[]>
            {
                new object[] { new UserDTO() { Email = "email", Password = "a" } },
                new object[] { new UserDTO() { Email = "tydacyda", Password = "12353223" } },
                new object[] { new UserDTO() { Email = "email@gmail.com", Password = "a" } },
            };

        [Theory]
        [MemberData(nameof(GetUsersForLogin))]
        public void Login_UserDTO_ThrowException(UserDTO dto)
        {
            _unitOfWorkMock.Setup(uow => uow.Users.GetByEmail(It.IsAny<string>())).Returns(() => null);

            var userService = new UserService(_unitOfWorkMock.Object, _passwordValidatorMock.Object, _tokenMock.Object, null, null, _validatorMock.Object);

            Assert.Throws<AuthorizationException>(() =>
            {
                userService.TryLogin(dto);
            });
        }

        [Theory]
        [MemberData(nameof(GetUsersForLogin))]
        public void Login_UserDTO_ReturnToken(UserDTO dto)
        {
            _unitOfWorkMock.Setup(uow => uow.Users.GetByEmail(It.IsAny<string>())).Returns(new User());

            var userService = new UserService(_unitOfWorkMock.Object, _passwordValidatorMock.Object, _tokenMock.Object, null, null, _validatorMock.Object);
            var response = userService.TryLogin(dto);

            Assert.True(response != null && response.Code == StatusCodes.Success);
        }
    }
}