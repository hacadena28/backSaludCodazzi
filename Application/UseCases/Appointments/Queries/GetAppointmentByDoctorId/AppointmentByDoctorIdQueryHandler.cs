using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByDoctorId;

public class
    AppointmentByDoctorIdQueryHandler : IRequestHandler<AppointmentByDoctorIdQuery, ResponsePagination<AppointmentDto>>
{
    private readonly IGenericRepository<Appointment> _repository;
    private readonly AppointmentService _appointmentServices;
    private readonly IMapper _mapper;

    public AppointmentByDoctorIdQueryHandler(IGenericRepository<Appointment>? repository,
        AppointmentService appointmentServices,
        IMapper mapper) =>
        (_repository, _appointmentServices, _mapper) = (repository, appointmentServices, mapper);

    public async Task<ResponsePagination<AppointmentDto>> Handle(AppointmentByDoctorIdQuery request,
        CancellationToken cancellationToken)
    {
        var appointmentFilterByDoctorId =
            await _appointmentServices.GetByDoctorId(request.DoctoId, request.Page, request.RecordsPerPage);
        var data = _mapper.Map<List<AppointmentDto>>(appointmentFilterByDoctorId.Records);

        return new ResponsePagination<AppointmentDto>
        {
            Page = request.Page,
            Records = data,
            TotalPages = appointmentFilterByDoctorId.TotalPages,
            TotalRecords = appointmentFilterByDoctorId.TotalRecords
        };
    }
}