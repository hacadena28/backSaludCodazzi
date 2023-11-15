using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreateDoctor;

public class UserCreateDoctorCommandHandler : IRequestHandler<UserCreateDoctorCommand, EmptyUserDto>
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public UserCreateDoctorCommandHandler(UserService userService, IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyUserDto> Handle(UserCreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.Role = Role.Doctor;
        await _userService.CreateUser(user);
        return new EmptyUserDto();
    }
}