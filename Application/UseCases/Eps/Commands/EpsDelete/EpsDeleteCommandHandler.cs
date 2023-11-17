using Application.Common.Exceptions;
using Application.UseCases.Eps.Queries.GetEps;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Eps.Commands.EpsDelete
{
    public class EpsDeleteCommandHandler : IRequestHandler<EpsDeleteCommand>
    {
        private readonly EpsService _epsService;
        private readonly IGenericRepository<Domain.Entities.Eps> _epsRepository;

        private readonly IMapper _mapper;


        public EpsDeleteCommandHandler(EpsService epsService, IGenericRepository<Domain.Entities.Eps> epsRepository,
            IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(EpsDeleteCommand request, CancellationToken cancellationToken)
        {
            var eps = await _epsRepository.GetByIdAsync(request.Id);
            await _epsService.DeleteEps(eps);
            return Unit.Value;
        }
    }
}