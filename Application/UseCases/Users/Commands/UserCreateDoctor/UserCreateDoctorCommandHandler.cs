using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreateDoctor;

public class UserCreateDoctorCommandHandler : IRequestHandler<UserCreateDoctorCommand>
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public UserCreateDoctorCommandHandler(UserService userService, IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(UserCreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Domain.Entities.Doctor();
        doctor.FirstName = request.Doctor.FirstName;
        doctor.SecondName = request.Doctor.SecondName;
        doctor.LastName = request.Doctor.LastName;
        doctor.SecondLastName = request.Doctor.SecondLastName;
        doctor.DocumentType = request.Doctor.DocumentType;
        doctor.DocumentNumber = request.Doctor.DocumentNumber;
        doctor.Email = request.Doctor.Email;
        doctor.Phone = request.Doctor.Phone;
        doctor.Address = request.Doctor.Address;
        doctor.Birthdate = request.Doctor.Birthdate;
        doctor.Specialization = request.Doctor.Specialization;

        var user = new User();
        user.Person = doctor;
        user.Role = Role.Doctor;
        user.Password = request.Password;
        await _userService.CreateUser(user);
        return Unit.Value;
    }
}