using Domain.Enums;

namespace Application.UseCases.Users.Commands.UserCreatePatient;

public class UserCreatePatientValidator : AbstractValidator<UserCreatePatientCommand>
{
    public UserCreatePatientValidator()
    {
        RuleFor(c => c.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(50);
        RuleFor(c => c.Patient).NotNull();
    }
}