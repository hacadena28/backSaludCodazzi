using Domain.Services;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand>
    {
        private readonly UserService _userService;

        public UserUpdateCommandHandler(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<Unit> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUser(request.Id, request.Password.Trim());
            return new Unit();
        }
    }
}