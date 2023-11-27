using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByWeek;

public record AppointmentsForDoctorByWeekQuery(Guid DoctorId, int Year, int WeekNumber) : IRequest<List<AppointmentDto>>;