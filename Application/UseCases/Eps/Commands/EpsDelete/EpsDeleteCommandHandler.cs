using Application.Common.Exceptions;
using Application.UseCases.Eps.Queries.GetEps;
using Domain.Services;

namespace Application.UseCases.Eps.Commands.EpsDelete
{
    public class EpsDeleteCommandHandler : IRequestHandler<EpsDeleteCommand, EmptyEpsDto>
    {
        private readonly EpsService _epsService;
        private readonly IMapper _mapper;


        public EpsDeleteCommandHandler(EpsService epsService,IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<EmptyEpsDto> Handle(EpsDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingEps = await _epsService.GetById(_mapper.Map<Domain.Entities.Eps>(request));

            if (existingEps == null)
                throw new EntityNotFound(Messages.EntityNotFound);
            else
            {
                await _epsService.DeleteEps(existingEps);
                return new EmptyEpsDto();
            }
        }
    }
}