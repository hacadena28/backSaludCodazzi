using Application.Common.Exceptions;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, EmptyUserDto>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserUpdateCommandHandler(UserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmptyUserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Id = request.Id;
            user.Password = request.Password;
            await _userService.UpdatedUser(user);
            return new EmptyUserDto();
        }
    }
}