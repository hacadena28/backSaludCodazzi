using Application.Common.Helpers.Pagination;
using Application.UseCases.Users.Queries.GetPaginationUser;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Queries.GetUserByRol;

public class UserByRolQueryHandler : IRequestHandler<UserByRolQuery, List<UserDto>>
{
    private readonly IGenericRepository<User> _repository;
    private readonly UserService _userServices;
    private readonly IMapper _mapper;

    public UserByRolQueryHandler(IGenericRepository<User>? repository, UserService userServices, IMapper mapper) =>
        (_repository, _userServices, _mapper) = (repository, userServices, mapper);

    public async Task<List<UserDto>> Handle(UserByRolQuery request, CancellationToken cancellationToken)
    {
        var userFilterByRol = await _userServices.GetUsersByRole(request.Role);
        var data = _mapper.Map<List<UserDto>>(userFilterByRol);


        return data;
    }
}