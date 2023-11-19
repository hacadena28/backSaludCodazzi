namespace Application.UseCases.Users.Commands.UserCreatePatient;

public class UserCreatePatientValidator : AbstractValidator<UserCreatePatientCommand>
{
    public UserCreatePatientValidator()
    {
        RuleFor(c => c.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(50);
        RuleFor(c => c.Patient).NotNull();
        RuleFor(c => c.Patient.FirstName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Patient.SecondName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Patient.LastName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Patient.SecondLastName).NotNull().MinimumLength(2).MaximumLength(40);
        RuleFor(c => c.Patient.DocumentType).NotNull();
        RuleFor(c => c.Patient.DocumentNumber).NotNull().MinimumLength(6).MaximumLength(10)
            .Must(x => int.TryParse(x, out _))
            .WithMessage("El campo debe ser un número.");
        RuleFor(c => c.Patient.Email).NotNull().MinimumLength(4).MaximumLength(40);
        RuleFor(c => c.Patient.Email).NotEmpty().EmailAddress().WithMessage("El correo electrónico no es válido.");
        RuleFor(c => c.Patient.Phone).NotNull().MinimumLength(6).MaximumLength(10);
        RuleFor(c => c.Patient.Phone).NotEmpty()
            .Must(x => int.TryParse(x, out _))
            .WithMessage("El campo debe ser un número.");
        RuleFor(c => c.Patient.Address).NotNull().MaximumLength(40);
        RuleFor(c => c.Patient.Birthdate).NotNull();
        RuleFor(c => c.Patient.EpsId).NotNull();
    }
}