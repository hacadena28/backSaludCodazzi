using Application.UseCases.Eps.Commands.EpsUpdate;
using Application.UseCases.Eps.Queries.GetEps;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Eps.Commands.EpsDelete
{
    public class EpsDeleteCommandHandler : IRequestHandler<EpsDeleteCommand, EpsDtoEmpty>
    {
        private readonly EpsService _epsService;
        private readonly IGenericRepository<Domain.Entities.Eps> _epsRepository;

        public EpsDeleteCommandHandler(EpsService epsService,
            IGenericRepository<Domain.Entities.Eps> epsRepository, IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        }

        public async Task<EpsDtoEmpty> Handle(EpsDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingEps = await _epsRepository.GetByIdAsync(request.Id);

            if (existingEps == null)
                return new EpsDtoEmpty();
            else
            {
                await _epsService.DeleteEps(existingEps);
                return new EpsDtoEmpty();
            }
        }
    }
}