using Domain.Enums;

namespace Application.UseCases.Medics.Commands.DoctorUpdate
{
    public class DoctorUpdateValidator : AbstractValidator<DoctorUpdateCommand>
    {
        public DoctorUpdateValidator()
        {
            RuleFor(_ => _.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(_ => _.SecondName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(_ => _.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(_ => _.SecondLastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(_ => _.Email).NotNull().NotEmpty().MinimumLength(4).MaximumLength(40).EmailAddress();
            RuleFor(_ => _.Phone).NotNull().NotEmpty()
                .Must(num => num.ToString().Length >= 9 && num.ToString().Length <= 15);
            RuleFor(_ => _.Address).NotNull().NotEmpty().MinimumLength(4).MaximumLength(40);
        }
    }
}