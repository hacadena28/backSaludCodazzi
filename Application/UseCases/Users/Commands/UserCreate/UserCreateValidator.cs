using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Users.Commands.UserCreate;
    public class UserCreateValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidator()
        {
            RuleFor(c => c.Password).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(c => c.Role).NotNull().Must(role => Enum.IsDefined(typeof(Role), role));
            RuleFor(c => c.Person).NotNull();

        }
    }