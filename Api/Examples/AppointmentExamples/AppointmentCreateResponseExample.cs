using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Entities;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.AppointmentExamples
{
    public class AppointmentCreateResponseExample : IMultipleExamplesProvider<Unit>
    {
        public IEnumerable<SwaggerExample<Unit>> GetExamples()
        {
            yield return SwaggerExample.Create("crearAlarmaRequest", Unit.Value);
        }
    }
}