using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public record AppointmentCreateCommand(
    DateTime AppointmentStartDate,
    TypeAppointment Type,
    string Description,
    Guid UserId,
    Guid DoctorId
) : IRequest;