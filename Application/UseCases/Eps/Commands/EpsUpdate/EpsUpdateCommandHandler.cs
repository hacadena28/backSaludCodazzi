using Application.Common.Exceptions;
using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;


namespace Application.UseCases.Eps.Commands.EpsUpdate;

public class EpsUpdateCommandHandler : IRequestHandler<EpsUpdateCommand, EmptyEpsDto>
{
    private readonly EpsService _epsService;
    private readonly IMapper _mapper;

    public EpsUpdateCommandHandler(EpsService epsService,
        IGenericRepository<Domain.Entities.Eps> epsRepository, IMapper mapper)
    {
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyEpsDto> Handle(EpsUpdateCommand request, CancellationToken cancellationToken)
    {
        var existingEps = await _epsService.GetById(_mapper.Map<Domain.Entities.Eps>(request));

        if (existingEps == null)
        {
            throw new EntityNotFound(Messages.EntityNotFound);
        }

        if (existingEps.Id == request.Id)
        {
            if (request.EpsName != null)
            {
                existingEps.Name = request.EpsName;
            }

            if (request.State != null)
            {
                existingEps.State = (EpsState)request.State;

                await _epsService.UpdatedEps(existingEps);
            }
        }

        return new EmptyEpsDto();
    }
}