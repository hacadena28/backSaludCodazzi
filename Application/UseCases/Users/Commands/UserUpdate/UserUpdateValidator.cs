using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateValidator()
        {
            RuleFor(_ => _.Id).NotNull().NotEmpty();
            RuleFor(_ => _.Password).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
        }
    }
}