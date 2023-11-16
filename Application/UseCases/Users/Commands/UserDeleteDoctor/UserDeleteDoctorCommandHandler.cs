using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDeleteDoctor
{
    public class UserDeleteDoctorCommandHandler : IRequestHandler<UserDeleteDoctorCommand>
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

        public async Task<Unit> Handle(UserDeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUser(request.Id);
            return Unit.Value;
        }
    }
}