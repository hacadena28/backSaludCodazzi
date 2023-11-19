using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreateDoctor;

public class UserCreateDoctorCommandHandler : IRequestHandler<UserCreateDoctorCommand>
{
    private readonly UserService _userService;
    private readonly IGenericRepository<Doctor> _doctorRepository;

    public UserCreateDoctorCommandHandler(UserService userService, IGenericRepository<Doctor> doctorRepository,
        IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
    }

    public async Task<Unit> Handle(UserCreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor(
            request.Doctor.FirstName,
            request.Doctor.SecondName,
            request.Doctor.LastName,
            request.Doctor.SecondLastName,
            request.Doctor.DocumentType,
            request.Doctor.DocumentNumber,
            request.Doctor.Email,
            request.Doctor.Phone,
            request.Doctor.Address,
            request.Doctor.Birthdate,
            request.Doctor.Specialization
        );

        var user = new User(request.Password, Role.Doctor, doctor);
        await _doctorRepository.AddAsync(doctor);
        await _userService.CreateUser(user);
        return Unit.Value;
    }
}