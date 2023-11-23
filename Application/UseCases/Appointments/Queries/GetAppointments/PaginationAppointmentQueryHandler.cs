using Application.Common.Helpers.Pagination;
using Domain.Ports;

namespace Application.UseCases.Appointments.Queries.GetAppointments;

public class
    PaginationAppointmentQueryHandler : IRequestHandler<PaginationAppointmentQuery, ResponsePagination<AppointmentDto>>
{
    private readonly IGenericRepository<Domain.Entities.Appointment> _repository;
    private readonly IMapper _mapper;

    public PaginationAppointmentQueryHandler(IGenericRepository<Domain.Entities.Appointment>? repository,
        IMapper mapper) => (_repository, _mapper) = (repository, mapper);


    public async Task<ResponsePagination<AppointmentDto>> Handle(PaginationAppointmentQuery request,
        CancellationToken cancellationToken)
    {
        var appointmentsPaginated = await _repository.GetPagedAsync(request.Page, request.RecordsPerPage);
        var dataPaginated = _mapper.Map<List<AppointmentDto>>(appointmentsPaginated.Records);

        return new ResponsePagination<AppointmentDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = appointmentsPaginated.TotalPages,
            TotalRecords = appointmentsPaginated.TotalRecords
        };
    }
}