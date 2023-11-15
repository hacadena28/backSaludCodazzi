using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDeletePatient
{
    public class UserDeletePatientCommandHandler : IRequestHandler<UserDeletePatientCommand, EmptyUserDto>
    {
        private readonly UserService _userService;
        private readonly PatientService _patientService;
        private readonly IMapper _mapper;


        public UserDeletePatientCommandHandler(UserService userService, PatientService patientService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmptyUserDto> Handle(UserDeletePatientCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var existingUser = await _userService.GetById(user);
            var patient = new Domain.Entities.Patient();
            patient.Id = existingUser.PersonId;
            var existingPatient = await _patientService.GetById(patient);

            if (existingUser == null && existingPatient == null)
                return new EmptyUserDto();
            else
            {
                await _patientService.DeletePatient(existingPatient);
                await _userService.DeleteUser(existingUser);
                return new EmptyUserDto();
            }
        }
    }
}