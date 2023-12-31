﻿using Application.UseCases.Appointments.Commands.AppointmentsCreate;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.AppointmentExamples
{
    public class AppointmentCreateCommandExample : IMultipleExamplesProvider<AppointmentCreateCommand>
    {
        public IEnumerable<SwaggerExample<AppointmentCreateCommand>> GetExamples()
        {
            var appointmentCommand = new AppointmentCreateCommand(
                DateTime.Now,
                TypeAppointment.General,
                "Dolor de muelas",
                new Guid(),
                new Guid()
            );
            yield return SwaggerExample.Create("appointmentCreateCommand", appointmentCommand);
        }
    }
}