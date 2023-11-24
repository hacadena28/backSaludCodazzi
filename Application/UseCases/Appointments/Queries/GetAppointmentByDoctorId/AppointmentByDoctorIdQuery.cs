using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByDoctorId;

public record AppointmentByDoctorIdQuery(Guid DoctoId) : RequestPagination,
    IRequest<ResponsePagination<AppointmentDto>>;