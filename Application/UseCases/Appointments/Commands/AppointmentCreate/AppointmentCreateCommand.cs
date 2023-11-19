using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentCreate;

public record AppointmentCreateCommand(
    DateTime Date,
    TypeAppointment Type, 
    string Description,
    Guid PatientId, 
    Guid DoctorId
) : IRequest;