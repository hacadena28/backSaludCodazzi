using Application.Common.Helpers.Pagination;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Admins.Queries.GetAdmin;

public class PaginationAdminQueryHandler : IRequestHandler<PaginationAdminQuery, ResponsePagination<AdminDto>>
{
    private readonly IGenericRepository<Admin> _repository;
    private readonly IMapper _mapper;

    public PaginationAdminQueryHandler(IGenericRepository<Admin>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<ResponsePagination<AdminDto>> Handle(PaginationAdminQuery request,
        CancellationToken cancellationToken)
    {
        var adminsPaginated = await _repository.GetPagedAsync(request.Page, request.RecordsPerPage);
        var dataPaginated = _mapper.Map<List<AdminDto>>(adminsPaginated.Records);

        return new ResponsePagination<AdminDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = adminsPaginated.TotalPages,
            TotalRecords = adminsPaginated.TotalRecords
        };
    }
}