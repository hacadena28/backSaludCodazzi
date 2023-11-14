using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserDto>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserUpdateCommandHandler(UserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Id = request.Id;
            var existingUser = await _userService.GetById(user);

            if (existingUser == null)
            {
                throw new Exception("El usuario no se encontró o no existe.");
            }

            if (existingUser.Id == request.Id)
            {
                existingUser.Password = request.Password;

                await _userService.UpdatedUser(existingUser);

                var updatedUser = await _userService.GetById(existingUser);

                return _mapper.Map<UserDto>(updatedUser);
            }
            else
            {
                throw new Exception("Los id No Coinciden");
            }
        }
    }
}