namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetAttended;

public record AppointmetAttendedCommand(Guid Id) : IRequest;