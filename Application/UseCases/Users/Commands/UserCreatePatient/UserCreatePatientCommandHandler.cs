using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreatePatient;

public class UserCreatePatientCommandHandler : IRequestHandler<UserCreatePatientCommand, EmptyUserDto>
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public UserCreatePatientCommandHandler(UserService userService, EpsService epsService, IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyUserDto> Handle(UserCreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = _mapper.Map<Domain.Entities.Patient>(request.Patient);
        var user = _mapper.Map<User>(request);
        user.Person = patient;
        user.Role = Role.Patient;
        await _userService.CreateUser(user);
        return new EmptyUserDto();
    }
}