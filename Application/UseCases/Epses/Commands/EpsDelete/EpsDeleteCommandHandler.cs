using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Epses.Commands.EpsDelete
{
    public class EpsDeleteCommandHandler : IRequestHandler<EpsDeleteCommand>
    {
        private readonly EpsService _epsService;
        private readonly IGenericRepository<Domain.Entities.Eps> _epsRepository;


        public EpsDeleteCommandHandler(EpsService epsService, IGenericRepository<Domain.Entities.Eps> epsRepository)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        }

        public async Task<Unit> Handle(EpsDeleteCommand request, CancellationToken cancellationToken)
        {
            var eps = await _epsRepository.GetByIdAsync(request.Id);
            await _epsService.DeleteEps(eps);
            return Unit.Value;
        }
    }
}