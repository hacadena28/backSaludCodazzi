using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByPatientId;

public class
    AppointmentByPatientIdQueryHandler : IRequestHandler<AppointmentByPatientIdQuery,
        ResponsePagination<AppointmentDto>>
{
    private readonly IGenericRepository<User> _repository;
    private readonly AppointmentService _appointmentServices;
    private readonly IMapper _mapper;

    public AppointmentByPatientIdQueryHandler(IGenericRepository<User> repository,
        AppointmentService appointmentServices,
        IMapper mapper) =>
        (_repository, _appointmentServices, _mapper) = (repository, appointmentServices, mapper);

    public async Task<ResponsePagination<AppointmentDto>> Handle(AppointmentByPatientIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = (await _repository.GetAsync(x => x.Id == request.PatientId, includeStringProperties: "Person")).FirstOrDefault();
    
        var appointmentFilterByPatientId =
            await _appointmentServices.GetByPatientId(user!.Person.Id, request.Page, request.RecordsPerPage);
        var data = _mapper.Map<List<AppointmentDto>>(appointmentFilterByPatientId.Records);

        return new ResponsePagination<AppointmentDto>
        {
            Page = request.Page,
            Records = data,
            TotalPages = appointmentFilterByPatientId.TotalPages,
            TotalRecords = appointmentFilterByPatientId.TotalRecords
        };
    }
}