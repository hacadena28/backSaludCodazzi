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
            var existingUser = await _userService.GetById(_mapper.Map<User>(request));

            if (existingUser == null)
            {
                throw new EntityNotFound(Messages.EntityNotFound);
            }

            if (existingUser.Id == request.Id)
            {
                existingUser.Password = request.Password;

                await _userService.UpdatedUser(existingUser);

                var updatedUser = await _userService.GetById(existingUser);

                return _mapper.Map<EmptyUserDto>(updatedUser);
            }

            return new EmptyUserDto();
        }
    }
}