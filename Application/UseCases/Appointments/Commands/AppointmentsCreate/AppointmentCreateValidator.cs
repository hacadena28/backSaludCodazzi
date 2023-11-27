using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public class AppointmentCreateValidator : AbstractValidator<AppointmentCreateCommand>
{
    public AppointmentCreateValidator()
    {
        RuleFor(_ => _.AppointmentStartDate)
            .NotNull()
            .Must(BeAValidDate).WithMessage("Ingrese una fecha válida.")
            .GreaterThan(DateTime.Today).WithMessage("La fecha debe ser en el futuro.")
            .Must(BeInValidTimeSlot)
            .WithMessage("La cita debe estar en intervalos de 30 minutos y entre las horas permitidas.");
        RuleFor(_ => _.Type).NotNull().Must(type => Enum.IsDefined(typeof(TypeAppointment), type));
        RuleFor(_ => _.Description).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(_ => _.PatientId).NotNull();
        RuleFor(_ => _.DoctorId).NotNull();
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }

    private bool BeInValidTimeSlot(DateTime date)
    {
        return (date.Hour >= 8 && date.Hour < 12 && date.Minute % 30 == 0) ||
               (date.Hour >= 14 && date.Hour < 18 && date.Minute % 30 == 0);
    }
}