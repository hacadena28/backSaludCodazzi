namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetReschedule
{
    public record AppointmetRescheduleCommand(Guid Id, DateTime NewDate) : IRequest;
}