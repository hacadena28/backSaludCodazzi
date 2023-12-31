﻿using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public class AppointmentCreateValidator : AbstractValidator<AppointmentCreateCommand>
{
    public AppointmentCreateValidator()
    {
        RuleFor(_ => _.AppointmentStartDate).NotNull().Must(BeAValidDate).WithMessage("Ingrese una fecha válida.")
            .GreaterThan(DateTime.Today)
            .WithMessage("La fecha debe ser en el futuro.");
        RuleFor(_ => _.Type).NotNull().Must(type => Enum.IsDefined(typeof(TypeAppointment), type));
        RuleFor(_ => _.Description).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(_ => _.UserId).NotNull();
        RuleFor(_ => _.DoctorId).NotNull();
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}