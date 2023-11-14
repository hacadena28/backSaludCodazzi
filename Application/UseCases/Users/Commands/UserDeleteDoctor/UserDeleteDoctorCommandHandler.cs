using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDeleteDoctor
{
    public class UserDeleteDoctorCommandHandler : IRequestHandler<UserDeleteDoctorCommand, EmptyUserDto>
    {
        private readonly UserService _userService;
        private readonly DoctorService _doctorService;

        public UserDeleteDoctorCommandHandler(UserService userService, DoctorService doctorService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        public async Task<EmptyUserDto> Handle(UserDeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Id = request.Id;
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