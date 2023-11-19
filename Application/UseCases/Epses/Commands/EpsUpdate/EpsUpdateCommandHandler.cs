using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Epses.Commands.EpsUpdate;

public class EpsUpdateCommandHandler : IRequestHandler<EpsUpdateCommand>
{
    private readonly EpsService _epsService;

    public EpsUpdateCommandHandler(EpsService epsService
    )
    {
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
    }

    public async Task<Unit> Handle(EpsUpdateCommand request, CancellationToken cancellationToken)
    {
        await _epsService.Update(request.Id, request.newName.Trim());
        return Unit.Value;
    }
}