using Domain.Enums;

namespace Application.UseCases.Users.Commands.UserCreateDoctor;

public class UserCreateDoctorValidator : AbstractValidator<UserCreateDoctorCommand>
{
    public UserCreateDoctorValidator()
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
        RuleFor(c => c.Doctor.Phone).NotNull().MinimumLength(6).MaximumLength(10);
        RuleFor(c => c.Doctor.Address).NotNull().MaximumLength(40);
        RuleFor(c => c.Doctor.Birthdate).NotNull();
        RuleFor(c => c.Doctor.Specialization).NotNull();
    }
}