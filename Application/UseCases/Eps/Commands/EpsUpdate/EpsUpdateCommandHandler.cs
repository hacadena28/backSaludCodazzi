using Application.UseCases.Eps.Queries.GetEps;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Eps.Commands.EpsUpdate
{
    public class EpsUpdateCommandHandler : IRequestHandler<EpsUpdateCommand, EpsDto>
    {
        private readonly EpsService _epsService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.Eps> _epsRepository;

        public EpsUpdateCommandHandler(EpsService epsService,
            IGenericRepository<Domain.Entities.Eps> epsRepository, IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        }

        public async Task<EpsDto> Handle(EpsUpdateCommand request, CancellationToken cancellationToken)
        {
            var existingEps = await _epsRepository.GetByIdAsync(request.Id);

            if (existingEps == null)
            {
                throw new Exception("La EPS no se encontró o no existe.");
            }

            if (existingEps.Id == request.Id)
            {
                existingEps.Name = request.EpsName;
                existingEps.State = request.State;

                await _epsService.UpdatedEps(existingEps);

                var updatedEps = await _epsRepository.GetByIdAsync(request.Id);

                return _mapper.Map<EpsDto>(updatedEps);
            }
            else
            {
                throw new Exception("Los id No Coinciden");
            }
        }
    }
}