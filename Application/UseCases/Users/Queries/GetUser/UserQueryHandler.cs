using Domain.Ports;

namespace Application.UseCases.Users.Queries.GetUser;

public class UserQueryHandler : IRequestHandler<UserQuery, List<UserDto>>
{
    private readonly IGenericRepository<Domain.Entities.User> _repository;
    private readonly IMapper _mapper;

    public UserQueryHandler(IGenericRepository<Domain.Entities.User>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<List<UserDto>> Handle(UserQuery request, CancellationToken cancellationToken)
    {
        var user = (await _repository.GetAsync()).ToList();
        return _mapper.Map<List<UserDto>>(user);
    }
}