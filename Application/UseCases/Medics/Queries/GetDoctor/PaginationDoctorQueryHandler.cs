using Application.Common.Helpers.Pagination;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Medics.Queries.GetDoctor;

public class PaginationDoctorQueryHandler : IRequestHandler<PaginationDoctorQuery, ResponsePagination<DoctorDto>>
{
    private readonly IGenericRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public PaginationDoctorQueryHandler(IGenericRepository<Doctor>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<ResponsePagination<DoctorDto>> Handle(PaginationDoctorQuery request,
        CancellationToken cancellationToken)
    {
        var doctorsPaginated = await _repository.GetPagedAsync(request.Page, request.RecordsPerPage);
        var dataPaginated = _mapper.Map<List<DoctorDto>>(doctorsPaginated.Records);

        return new ResponsePagination<DoctorDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = doctorsPaginated.TotalPages,
            TotalRecords = doctorsPaginated.TotalRecords
        };
    }
}