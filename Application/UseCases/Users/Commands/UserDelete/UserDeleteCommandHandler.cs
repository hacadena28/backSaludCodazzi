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
        private readonly IGenericRepository<Admin> _adminRepository;
        private readonly IGenericRepository<Doctor> _doctorRepository;


        public UserDeleteCommandCommandHandler(
            UserService userService,
            IGenericRepository<Admin> adminRepository,
            IGenericRepository<Patient> patientRepository,
            IGenericRepository<Doctor> doctorRepository,
            IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
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
            else if(user.Role == Role.Patient)
            {
                var patient = await _patientRepository.GetByIdAsync(user.PersonId);
                await _patientRepository.DeleteAsync(patient);
            }
            else if (user.Role == Role.Admin)
            {
                var patient = await _adminRepository.GetByIdAsync(user.PersonId);
                await _adminRepository.DeleteAsync(patient);
            }

            await _userService.DeleteUser(user);
            return new Unit();
        }
    }
}