using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreatePatient;

public class UserCreatePatientCommandHandler : IRequestHandler<UserCreatePatientCommand>
{
    private readonly UserService _userService;
    private readonly IGenericRepository<Patient> _patientRepository;

    public UserCreatePatientCommandHandler(UserService userService, IGenericRepository<Patient> patientRepository)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
    }

    public async Task<Unit> Handle(UserCreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Patient(
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
            request.Patient.EpsId
        );

        var user = new User(request.Password, Role.Patient, patient);
        await _patientRepository.AddAsync(patient);
        await _userService.CreateUser(user);
        return new Unit();
    }
}