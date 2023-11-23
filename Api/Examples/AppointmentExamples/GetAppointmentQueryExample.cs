using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Api.Examples.AppointmentExamples
{
    public class GetAppointmentQueryExample : IMultipleExamplesProvider<PaginationAppointmentQuery>
    {
        public IEnumerable<SwaggerExample<PaginationAppointmentQuery>> GetExamples()
        {
            var appointmentQuery = new PaginationAppointmentQuery();
            yield return SwaggerExample.Create("appointmentQuery", appointmentQuery);
        }
    }
}