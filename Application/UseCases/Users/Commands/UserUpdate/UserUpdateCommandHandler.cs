using Application.UseCases.User.Queries.GetUser;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.User.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserDto>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.User> _userRepository;

        public UserUpdateCommandHandler(UserService userService,
            IGenericRepository<Domain.Entities.User> userRepository, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id);

            if (existingUser == null)
            {
                throw new Exception("El usuario no se encontró o no existe.");
            }

            if (existingUser.Id == request.Id)
            {
                existingUser.Password = request.Password;
                existingUser.Role = request.Role;

                await _userService.UpdatedUser(existingUser);

                var updatedUser = await _userRepository.GetByIdAsync(request.Id);

                return _mapper.Map<UserDto>(updatedUser);
            }
            else
            {
                throw new Exception("Los id No Coinciden");
            }
        }
    }
}