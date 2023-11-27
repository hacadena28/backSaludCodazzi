using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetChangeState
{
    public record AppointmetChangeStateCommand(Guid Id, AppointmentState State, DateTime? NewDate) : IRequest;
}