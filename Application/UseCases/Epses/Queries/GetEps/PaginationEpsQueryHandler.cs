using Application.Common.Helpers.Pagination;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Epses.Queries.GetEps;

public class PaginationEpsQueryHandler : IRequestHandler<PaginationEpsQuery, ResponsePagination<EpsDto>>
{
    private readonly IGenericRepository<Eps> _repository;
    private readonly IMapper _mapper;

    public PaginationEpsQueryHandler(IGenericRepository<Eps>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    public async Task<ResponsePagination<EpsDto>> Handle(PaginationEpsQuery request,
        CancellationToken cancellationToken)
    {
        var epssPaginated = await _repository.GetPagedAsync(request.Page, request.RecordsPerPage);
        var dataPaginated = _mapper.Map<List<EpsDto>>(epssPaginated.Records);

        return new ResponsePagination<EpsDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = epssPaginated.TotalPages,
            TotalRecords = epssPaginated.TotalRecords
        };
    }
}