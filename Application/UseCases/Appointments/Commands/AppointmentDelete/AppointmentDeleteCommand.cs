using Application.UseCases.Appointment.Queries.GetAppointment;

namespace Application.UseCases.Appointments.Commands.AppointmentDelete
{
    public record AppointmentDeleteCommand(Guid Id) : IRequest;
}