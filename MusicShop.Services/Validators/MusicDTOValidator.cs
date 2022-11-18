using FluentValidation;
using MusicShop.Core.DTO;

namespace MusicShop.Services.Validators
{
    public class MusicDTOValidator : AbstractValidator<MusicDTO>
    {
        public MusicDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
