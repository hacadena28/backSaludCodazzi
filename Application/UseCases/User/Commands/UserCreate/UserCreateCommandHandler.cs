using Application.UseCases.User.Queries.GetUser;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.User.Commands.UserCreate;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserDtoEmpty>
{
    private readonly UserService _service;
    private readonly IMapper _mapper;

    public UserCreateCommandHandler(UserService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UserDtoEmpty> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        if(request.Role == Role.Patient)
        await _service.CreateUser(
            new Domain.Entities.User(request.Identification, request.Password, request.Role, request.PersonId,
                request.Person)
        );
        return new UserDtoEmpty();
    }
}