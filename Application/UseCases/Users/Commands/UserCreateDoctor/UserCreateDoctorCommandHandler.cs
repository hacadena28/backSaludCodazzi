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
            request.Doctor.FirstName.Trim(),
            request.Doctor.SecondName.Trim(),
            request.Doctor.LastName.Trim(),
            request.Doctor.SecondLastName.Trim(),
            request.Doctor.DocumentType,
            request.Doctor.DocumentNumber.Trim(),
            request.Doctor.Email.Trim(),
            request.Doctor.Phone.Trim(),
            request.Doctor.Address.Trim(),
            request.Doctor.Birthdate,
            request.Doctor.Specialization.Trim()
        );

        var user = new User(request.Password.Trim(), Role.Doctor, doctor);
        await _doctorRepository.AddAsync(doctor);
        await _userService.CreateUser(user);
        return Unit.Value;
    }
}