using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByDay;

public record AppointmentsForDoctorByDayQuery(Guid DoctorId, DateTime Date) : IRequest<List<AppointmentDto>>;