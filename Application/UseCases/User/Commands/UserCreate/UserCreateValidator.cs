using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.User.Commands.UserCreate;
    public class UserCreateValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidator()
        {
            RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(4).MaximumLength(11);
            RuleFor(_ => _.Password).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(_ => _.Role).NotNull().Must(role => Enum.IsDefined(typeof(Role), role));
            RuleFor(_ => _.PersonId).NotNull();
            RuleFor(_ => _.Person).NotNull();

        }
    }