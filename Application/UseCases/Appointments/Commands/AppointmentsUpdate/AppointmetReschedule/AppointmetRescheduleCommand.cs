namespace Application.UseCases.Appointments.Commands.AppointmentUpdate.AppointmetReschedule
{
    public record AppointmetRescheduleCommand(Guid Id, DateTime NewDate) : IRequest;
}