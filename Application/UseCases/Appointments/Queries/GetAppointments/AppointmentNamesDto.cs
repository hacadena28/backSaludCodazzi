using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases.Appointments.Queries.GetAppointments;

public record AppointmentNamesDto
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public DateTime AppointmentStartDate { get; init; }
    public DateTime AppointmentFinalDate { get; init; }
    public AppointmentState State { get; init; }
    public TypeAppointment Type { get; init; }
    public string Description { get; init; }
    public Guid PatientId { get; init; }
    public Guid DoctorId { get; init; }
    public string? PatientFullName { get; init; }
    public string? DoctorFullName { get; init; }
}