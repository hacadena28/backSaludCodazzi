using Application.Common.Helpers.Pagination;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Patients.Queries.GetPatient;

public class PaginationPatientQueryHandler : IRequestHandler<PaginationPatientQuery, ResponsePagination<PatientDto>>
{
    private readonly IGenericRepository<Patient> _repository;
    private readonly IMapper _mapper;

    public PaginationPatientQueryHandler(IGenericRepository<Patient>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<ResponsePagination<PatientDto>> Handle(PaginationPatientQuery request,
        CancellationToken cancellationToken)
    {
        var patientsPaginated = await _repository.GetPagedAsync(request.Page, request.RecordsPerPage);
        var dataPaginated = _mapper.Map<List<PatientDto>>(patientsPaginated.Records);
        return new ResponsePagination<PatientDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = patientsPaginated.TotalPages,
            TotalRecords = patientsPaginated.TotalRecords
        };
    }
}