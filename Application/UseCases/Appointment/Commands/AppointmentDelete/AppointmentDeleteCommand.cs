using Application.UseCases.Appointment.Queries.GetAppointment;

namespace Application.UseCases.Appointment.Commands.AppointmentDelete
{
    public record AppointmentDeleteCommand(Guid Id) : IRequest<EmptyAppointmentDto>;
}