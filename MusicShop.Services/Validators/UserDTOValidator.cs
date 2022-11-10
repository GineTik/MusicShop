using FluentValidation;
using Microsoft.Extensions.Configuration;
using MusicShop.Core.DTO;

namespace MusicShop.Services.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator(IConfiguration configuration)
        {
            var usernameMinLength = int.Parse(configuration["Validations:UserDTO:UsernameMinLength"]);
            var passwordMinLength = int.Parse(configuration["Validations:UserDTO:PasswordMinLength"]);

            RuleFor(x => x.Username).MinimumLength(usernameMinLength);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(passwordMinLength);
        }
    }
}
