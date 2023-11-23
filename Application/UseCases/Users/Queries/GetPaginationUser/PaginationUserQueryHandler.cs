using Application.Common.Helpers.Pagination;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Users.Queries.GetPaginationUser;

public class PaginationUserQueryHandler : IRequestHandler<PaginationUserQuery, ResponsePagination<UserDto>>
{
    private readonly IGenericRepository<User> _repository;
    private readonly IMapper _mapper;

    public PaginationUserQueryHandler(IGenericRepository<User>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    public async Task<ResponsePagination<UserDto>> Handle(PaginationUserQuery request,
        CancellationToken cancellationToken)
    {
        var usersPaginated = await _repository.GetPagedAsync(request.Page, request.RecordsPerPage);
        var dataPaginated = _mapper.Map<List<UserDto>>(usersPaginated.Records);


        return new ResponsePagination<UserDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = usersPaginated.TotalPages,
            TotalRecords = usersPaginated.TotalRecords
        };
    }
}