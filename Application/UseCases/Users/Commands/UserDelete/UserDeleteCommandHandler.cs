using Application.UseCases.User.Commands.UserDelete;
using Application.UseCases.User.Queries.GetUser;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, UserDtoEmpty>
    {
        private readonly UserService _epsService;
        private readonly IGenericRepository<Domain.Entities.User> _epsRepository;

        public UserDeleteCommandHandler(UserService epsService,
            IGenericRepository<Domain.Entities.User> epsRepository, IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        }

        public async Task<UserDtoEmpty> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _epsRepository.GetByIdAsync(request.Id);

            if (existingUser == null)
                return new UserDtoEmpty();
            else
            {
                await _epsService.DeleteUser(existingUser);
                return new UserDtoEmpty();
            }
        }
    }
}