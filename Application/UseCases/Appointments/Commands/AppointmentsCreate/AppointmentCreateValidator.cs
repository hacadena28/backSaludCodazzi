using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public class AppointmentCreateValidator : AbstractValidator<AppointmentCreateCommand>
{
    public AppointmentCreateValidator()
    {
        RuleFor(_ => _.AppointmentStartDate).NotNull();
        RuleFor(_ => _.Type).NotNull().Must(type => Enum.IsDefined(typeof(TypeAppointment), type));
        RuleFor(_ => _.Description).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(_ => _.PatientId).NotNull();
        RuleFor(_ => _.DoctorId).NotNull();
    }
}