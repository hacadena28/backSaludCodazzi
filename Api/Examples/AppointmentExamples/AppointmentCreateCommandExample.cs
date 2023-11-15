using Application.UseCases.Appointment.Commands.AppointmentCreate;
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
                AppointmentState.Scheduled,
                TypeAppointment.General,
                "Dolor de muelas",
                new Guid(),
                new Guid()
            );
            yield return SwaggerExample.Create("appointmentCreateCommand", appointmentCommand);
        }
    }
}