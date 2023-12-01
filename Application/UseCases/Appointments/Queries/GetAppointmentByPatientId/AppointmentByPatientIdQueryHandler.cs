using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByPatientId;

public class
    AppointmentByPatientIdQueryHandler : IRequestHandler<AppointmentByPatientIdQuery,
        ResponsePagination<AppointmentNamesDto>>
{
    private readonly IGenericRepository<User> _repository;
    private readonly AppointmentService _appointmentServices;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Doctor> _doctorRepository;
    private readonly IMapper _mapper;

    public AppointmentByPatientIdQueryHandler(IGenericRepository<User> repository,
        AppointmentService appointmentServices,
        IMapper mapper) =>
        (_repository, _appointmentServices, _mapper) = (repository, appointmentServices, mapper);

    public async Task<ResponsePagination<AppointmentNamesDto>> Handle(AppointmentByPatientIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = (await _repository.GetAsync(x => x.Id == request.PatientId, includeStringProperties: "Person"))
            .FirstOrDefault();

        var appointmentFilterByPatientId =
            await _appointmentServices.GetByPatientId(user!.Person.Id, request.Page, request.RecordsPerPage);

        // var dataPaginated = _mapper.Map<List<AppointmentNamesDto>>(appointmentFilterByPatientId.Records);
        var dataPaginated = appointmentFilterByPatientId.Records.Select(
            x => _mapper.Map<AppointmentNamesDto>(x)
        ).ToList();

        return new ResponsePagination<AppointmentNamesDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = appointmentFilterByPatientId.TotalPages,
            TotalRecords = appointmentFilterByPatientId.TotalRecords
        };
    }
}