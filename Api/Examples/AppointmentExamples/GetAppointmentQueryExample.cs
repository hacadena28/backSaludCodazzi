using Application.UseCases.Appointment.Queries.GetAppointment;

namespace Api.Examples.AppointmentExamples
{
    public class GetAppointmentQueryExample : IMultipleExamplesProvider<AppointmentQuery>
    {
        public IEnumerable<SwaggerExample<AppointmentQuery>> GetExamples()
        {
            var appointmentQuery = new AppointmentQuery();
            yield return SwaggerExample.Create("appointmentQuery", appointmentQuery);
        }
    }
}