using Application.UseCases.Users.Queries.GetPaginationUser;
using Application.UseCases.Users.Queries.GetUserByRol;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Queries.GetUserByID;

public class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, UserDto>
{
    private readonly IGenericRepository<User> _repository;
    private readonly UserService _userServices;
    private readonly IMapper _mapper;

    public UserByIdQueryHandler(IGenericRepository<User>? repository, UserService userServices, IMapper mapper) =>
        (_repository, _userServices, _mapper) = (repository, userServices, mapper);

    public async Task<UserDto> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        var userFilterById = await _userServices.GetById(request.Id);
        var data = _mapper.Map<UserDto>(userFilterById);
        return data;
    }
}