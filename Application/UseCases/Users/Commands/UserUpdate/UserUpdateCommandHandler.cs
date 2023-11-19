using Domain.Services;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserUpdateCommandHandler(UserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUser(request.Id, request.Password);
            return new Unit();
        }
    }
}