using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Appointments.Queries.GetAppointments;

public record PaginationAppointmentQuery : RequestPagination, IRequest<ResponsePagination<AppointmentDto>>;