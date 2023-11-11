using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.User.Commands.UserUpdate
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateValidator()
        {
            RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(4).MaximumLength(11);
            RuleFor(_ => _.Password).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(_ => _.Role).NotNull().Must(role => Enum.IsDefined(typeof(Role), role));
            RuleFor(_ => _.PersonId).NotNull().NotEmpty();
            
        }
    }
}