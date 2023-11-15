namespace Application.UseCases.Users.Commands.UserCreateDoctor;

public class UserCreateDoctorValidator : AbstractValidator<UserCreateDoctorCommand>
{
    public UserCreateDoctorValidator()
    {
        RuleFor(c => c.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(50);
        RuleFor(c => c.Doctor).NotNull();
    }
}