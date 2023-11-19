using Domain.Enums;

namespace Application.UseCases.Patients.Commands.PatientUpdate
{
    public class PatientUpdateValidator : AbstractValidator<PatientUpdateCommand>
    {
        public PatientUpdateValidator()
        {
            RuleFor(_ => _.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40)
                .When(_ => _.FirstName != null);

            RuleFor(_ => _.SecondName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40)
                .When(_ => _.SecondName != null);

            RuleFor(_ => _.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40)
                .When(_ => _.LastName != null);

            RuleFor(_ => _.SecondLastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40)
                .When(_ => _.SecondLastName != null);

            RuleFor(_ => _.Email).NotNull().NotEmpty().MinimumLength(4).MaximumLength(40).EmailAddress()
                .When(_ => _.Email != null);

            RuleFor(_ => _.Phone).NotNull().NotEmpty()
                .Must(num => num.ToString().Length >= 9 && num.ToString().Length <= 15).When(_ => _.Phone != null);

            RuleFor(_ => _.Address).NotNull().NotEmpty().MinimumLength(4).MaximumLength(40)
                .When(_ => _.Address != null);
        }
    }
}