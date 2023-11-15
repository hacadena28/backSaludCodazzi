﻿using Domain.Enums;

namespace Application.UseCases.Appointment.Commands.AppointmentUpdate
{
    public class AppointmentUpdateValidator : AbstractValidator<AppointmentUpdateCommand>
    {
        public AppointmentUpdateValidator()
        {
            RuleFor(_ => _.Date).NotNull();
            RuleFor(_ => _.State).NotNull().Must(state => Enum.IsDefined(typeof(AppointmentState), state));
            RuleFor(_ => _.Type).NotNull().Must(type => Enum.IsDefined(typeof(TypeAppointment), type));
            RuleFor(_ => _.Description).NotNull().NotEmpty().MinimumLength(1).MaximumLength(250);
            RuleFor(_ => _.DoctorId).NotNull();
        }
    }
}