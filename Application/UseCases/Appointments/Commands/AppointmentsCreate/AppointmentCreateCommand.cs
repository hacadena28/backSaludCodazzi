using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public record AppointmentCreateCommand(
    DateTime AppointmentStartDate,
    TypeAppointment Type,
    string Description,
    Guid PatientId,
    Guid DoctorId
) : IRequest;