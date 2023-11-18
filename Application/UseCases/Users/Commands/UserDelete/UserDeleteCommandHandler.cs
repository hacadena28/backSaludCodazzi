using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDelete
{
    public class UserDeleteCommandCommandHandler : IRequestHandler<UserDeleteCommand>
    {
        private readonly UserService _userService;


        public UserDeleteCommandCommandHandler(UserService userService, PatientService patientService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUser(request.Id);
            return new Unit();
        }
    }
}