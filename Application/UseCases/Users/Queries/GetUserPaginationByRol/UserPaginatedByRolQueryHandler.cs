using Application.Common.Helpers.Pagination;
using Application.UseCases.Users.Queries.GetPaginationUser;
using Application.UseCases.Users.Queries.GetUserByRol;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Queries.GetUserPaginationByRol;

public class UserPaginatedByRolQueryHandler : IRequestHandler<UserPaginatedByRolQuery, ResponsePagination<UserDto>>
{
    private readonly IGenericRepository<User> _repository;
    private readonly UserService _userServices;
    private readonly IMapper _mapper;

    public UserPaginatedByRolQueryHandler(IGenericRepository<User>? repository, UserService userServices,
        IMapper mapper) =>
        (_repository, _userServices, _mapper) = (repository, userServices, mapper);

    public async Task<ResponsePagination<UserDto>> Handle(UserPaginatedByRolQuery request,
        CancellationToken cancellationToken)
    {
        var userFilterByRol =
            await _userServices.GetUsersPaginationByRole(request.Page, request.RecordsPerPage, request.Role);
        var dataPaginated = _mapper.Map<List<UserDto>>(userFilterByRol.Records);


        return new ResponsePagination<UserDto>
        {
            Page = request.Page,
            Records = dataPaginated,
            TotalPages = userFilterByRol.TotalPages,
            TotalRecords = userFilterByRol.TotalRecords
        };
    }
}