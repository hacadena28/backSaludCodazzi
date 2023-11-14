using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreatePatient;

public class UserCreatePatientCommandHandler : IRequestHandler<UserCreatePatientCommand, EmptyUserDto>
{
    private readonly UserService _userService;
    private readonly EpsService _epsService;
    private readonly IMapper _mapper;

    public UserCreatePatientCommandHandler(UserService userService,EpsService epsService, IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyUserDto> Handle(UserCreatePatientCommand request, CancellationToken cancellationToken)
    {

        var eps = new Domain.Entities.Eps(
            request.Patient.Eps.Name, 
            request.Patient.Eps.State
            );
        
        eps = await _epsService.GetById(eps);
        var patient = new Domain.Entities.Patient(
            request.Patient.FirstName,
            request.Patient.SecondName,
            request.Patient.LastName,
            request.Patient.SecondLastName,
            request.Patient.DocumentType,
            request.Patient.DocumentNumber,
            request.Patient.Email,
            request.Patient.Phone,
            request.Patient.Address,
            request.Patient.Birthdate,
            eps
        );
        var user = new Domain.Entities.User(request.Password, Role.Patient, patient);
        await _userService.CreateUser(user);
        return new EmptyUserDto();
    }
}