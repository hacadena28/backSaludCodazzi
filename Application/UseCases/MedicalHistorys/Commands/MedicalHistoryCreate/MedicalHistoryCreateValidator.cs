using Domain.Enums;

namespace Application.UseCases.MedicalHistorys.Commands.MedicalHistoryCreate;

public class MedicalHistoryCreateValidator : AbstractValidator<MedicalHistoryCreateCommand>
{
    public MedicalHistoryCreateValidator()
    {
        RuleFor(_ => _.Date).NotNull().Must(BeAValidDate).WithMessage("Ingrese una fecha válida.")
            .GreaterThan(DateTime.Today)
            .WithMessage("La fecha debe ser en el futuro.");
        RuleFor(_ => _.Description).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(_ => _.Diagnosis).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(_ => _.Treatment).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(_ => _.DoctorId).NotNull();
        RuleFor(_ => _.PatientId).NotNull();
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}