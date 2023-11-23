using Domain.Enums;

namespace Application.UseCases.Appointments.Queries.GetAppointments;

public record AppointmentDto(Guid Id, DateTime Date, AppointmentState State, TypeAppointment Type, string Description,
    Guid PatientId, Guid DoctorId);