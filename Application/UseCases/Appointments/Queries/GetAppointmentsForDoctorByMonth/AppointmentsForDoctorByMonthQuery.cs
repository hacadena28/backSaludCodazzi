using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByMonth;

public record AppointmentsForDoctorByMonthQuery(Guid DoctorId, int Year, int Month) : IRequest<List<AppointmentDto>>;