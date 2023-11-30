using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByMonth;

public record AppointmentsForDoctorByMonthQuery(Guid DoctorId, DateTime Date) : IRequest<List<AppointmentDto>>;