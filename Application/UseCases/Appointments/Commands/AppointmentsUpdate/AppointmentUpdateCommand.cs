using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentUpdate
{
    public record AppointmentUpdateCommand(Guid Id, DateTime Date, AppointmentState State) : IRequest;
}