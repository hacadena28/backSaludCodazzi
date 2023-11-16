using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDeleteDoctor
{
    public class UserDeleteDoctorCommandHandler : IRequestHandler<UserDeleteDoctorCommand, EmptyUserDto>
    {
        private readonly UserService _userService;
        private readonly DoctorService _doctorService;
        private readonly PatientService _patientService;
        private readonly IMapper _mapper;

        public UserDeleteDoctorCommandHandler(UserService userService, DoctorService doctorService,
            PatientService patientService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmptyUserDto> Handle(UserDeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var existingUser = await _userService.GetById(user);

            var doctor = new Domain.Entities.Doctor();


            doctor.Id = existingUser.PersonId;
            var existingDoctor = await _doctorService.GetById(doctor);

            if (existingUser == null && existingDoctor == null)
                return new EmptyUserDto();
            else
            {
                await _doctorService.DeleteDoctor(existingDoctor);
                await _userService.DeleteUser(existingUser);
                return new EmptyUserDto();
            }
        }
    }
}