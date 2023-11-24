using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByPatientId;

public record AppointmentByPatientIdQuery(Guid PatientId) : RequestPagination,
    IRequest<ResponsePagination<AppointmentDto>>;