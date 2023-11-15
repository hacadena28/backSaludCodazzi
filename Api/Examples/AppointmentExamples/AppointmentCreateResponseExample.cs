using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.AppointmentExamples
{
    public class AppointmentCreateResponseExample : IMultipleExamplesProvider<EmptyAppointmentDto>
    {
        public IEnumerable<SwaggerExample<EmptyAppointmentDto>> GetExamples()
        {
            var emptyAppointmentDto = new EmptyAppointmentDto();
            yield return SwaggerExample.Create("crearAlarmaRequest", emptyAppointmentDto);
        }
    }
}