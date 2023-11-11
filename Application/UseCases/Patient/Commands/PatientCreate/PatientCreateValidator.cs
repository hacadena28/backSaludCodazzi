using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Patient.Commands.PatientCreate;

public class PatientCreateValidator : AbstractValidator<PatientCreateCommand>
{
    public PatientCreateValidator()
    {
        RuleFor(_ => _.firstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
        RuleFor(_ => _.secondName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
        RuleFor(_ => _.lastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
        RuleFor(_ => _.secondLastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
        RuleFor(_ => _.documentType).NotNull().Must(typeDocument => Enum.IsDefined(typeof(TypeDocument), typeDocument));
        RuleFor(_ => _.documentNumber).NotNull().NotEmpty().MinimumLength(4).MaximumLength(15);
        RuleFor(_ => _.email).NotNull().NotEmpty().MinimumLength(4).MaximumLength(40).EmailAddress();
        RuleFor(_ => _.phone).NotNull().NotEmpty()
            .Must(num => num.ToString().Length >= 9 && num.ToString().Length <= 15);
        RuleFor(_ => _.address).NotNull().NotEmpty().MinimumLength(4).MaximumLength(40);
        RuleFor(_ => _.birthdate).NotNull().NotEmpty();
    }
}