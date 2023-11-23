namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetCancel
{
    public record AppointmetCancelCommand(Guid Id) : IRequest;
}