using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Enums;

namespace Application.UseCases.Appointment.Commands.AppointmentCreate;

public record AppointmentCreateCommand(
    DateTime Date,
    AppointmentState State, 
    TypeAppointment Type, 
    string Description,
    Guid PatientId, 
    Guid DoctorId
) : IRequest<EmptyAppointmentDto>;