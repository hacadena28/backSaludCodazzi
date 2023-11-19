using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDelete
{
    public class UserDeleteCommandCommandHandler : IRequestHandler<UserDeleteCommand>
    {
        private readonly UserService _userService;
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Doctor> _doctorRepository;


        public UserDeleteCommandCommandHandler(
            UserService userService,
            IGenericRepository<User> userRepository,
            IGenericRepository<Patient> patientRepository,
            IGenericRepository<Doctor> doctorRepository,
            IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(request.Id);
            if (user.Role == Role.Doctor)
            {
                var doctor = await _doctorRepository.GetByIdAsync(user.PersonId);
                await _doctorRepository.DeleteAsync(doctor);
            }
            else
            {
                var patient = await _patientRepository.GetByIdAsync(user.PersonId);
                await _patientRepository.DeleteAsync(patient);
            }

            await _userService.DeleteUser(user);
            return new Unit();
        }
    }
}