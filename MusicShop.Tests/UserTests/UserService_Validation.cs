using Microsoft.Extensions.Configuration;
using MusicShop.Core.DTO;
using MusicShop.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MusicShop.Tests.UserTests
{
    public class UserService_Validation
    {
        public readonly IConfiguration _configuration;
        public readonly UserDTOValidator _validator;

        public UserService_Validation()
        {
            // TODO: знати гарний спосіб додати сюди налаштування з appsettings.json
            var inMemorySettings = new Dictionary<string, string> {
                {"Validations:UserDTO:UsernameMinLength", "3"},
                {"Validations:UserDTO:PasswordMinLength", "3"},
                //...populate as needed for the test
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _validator = new UserDTOValidator(_configuration);
        }

        public static IEnumerable<object[]> GetUsersForVaidation_ReturnFalse =>
            new List<object[]>
            {
                new object[] { new UserDTO() { Email = "email", Password = "a" } },
                new object[] { new UserDTO() { Email = "tydacyda", Password = "12353223" } },
                new object[] { new UserDTO() { Email = "email@gmail.com", Password = "a" } },
            };

        [Theory]
        [MemberData(nameof(GetUsersForVaidation_ReturnFalse))]
        public void Validation_UserDTO_ReturnFalse(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            Assert.False(result.IsValid, String.Join(",\n", result.Errors.Select(x => x.ErrorMessage)));
        }

        public static IEnumerable<object[]> GetUsersForVaidation_ReturnTrue =>
            new List<object[]>
            {
                new object[] { new UserDTO() { Email = "email@gmail.com", Password = "pass" } },
                new object[] { new UserDTO() { Email = "tydacyda@gmail.com", Password = "12353223" } },
                new object[] { new UserDTO() { Email = "email@gmail.com", Password = "a123a" } },
            };

        [Theory]
        [MemberData(nameof(GetUsersForVaidation_ReturnTrue))]
        public void Validation_UserDTO_ReturnTrue(UserDTO dto)
        {
            var result = _validator.Validate(dto);
            Assert.True(result.IsValid);
        }
    }
}