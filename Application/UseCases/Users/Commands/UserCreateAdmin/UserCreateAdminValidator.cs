using Application.UseCases.Users.Commands.UserCreateDoctor;

namespace Application.UseCases.Users.Commands.UserCreateAdmin;

public class UserCreateAdminValidator : AbstractValidator<UserCreateDoctorCommand>
{
    public UserCreateAdminValidator()
    {
        RuleFor(c => c.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(50);
        RuleFor(c => c.Doctor).NotNull();
        RuleFor(c => c.Doctor.FirstName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Doctor.SecondName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Doctor.LastName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Doctor.SecondLastName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Doctor.DocumentType).NotNull();
        RuleFor(c => c.Doctor.DocumentNumber).NotNull().MinimumLength(6).MaximumLength(10);
        RuleFor(c => c.Doctor.Email).NotNull().MinimumLength(4).MaximumLength(40);
        RuleFor(c => c.Doctor.Email).NotEmpty().EmailAddress().WithMessage("El correo electrónico no es válido.");
        RuleFor(c => c.Doctor.Phone).NotNull().MinimumLength(6).MaximumLength(10);
        RuleFor(c => c.Doctor.Phone).NotEmpty();
        RuleFor(c => c.Doctor.Address).NotNull().MaximumLength(40);
        RuleFor(c => c.Doctor.Birthdate).NotNull();
    }
}