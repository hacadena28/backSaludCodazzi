using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreatePatient;

public class UserCreatePatientCommandHandler : IRequestHandler<UserCreatePatientCommand, EmptyUserDto>
{
    private readonly UserService _userService;
    private readonly EpsService _epsService;
    private readonly IMapper _mapper;

    public UserCreatePatientCommandHandler(UserService userService, EpsService epsService, IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyUserDto> Handle(UserCreatePatientCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.Role = Role.Patient;
        await _userService.CreateUser(user);
        return new EmptyUserDto();
    }
}