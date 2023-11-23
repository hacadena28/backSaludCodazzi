namespace Application.UseCases.Appointments.Commands.AppointmentsDelete
{
    public record AppointmentDeleteCommand(Guid Id) : IRequest;
}