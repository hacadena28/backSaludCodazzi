using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Epses.Commands.EpsUpdate;

public class EpsChangeStateCommandHandler : IRequestHandler<EpsChangeStateCommand>
{
    private readonly EpsService _epsService;
    private readonly IGenericRepository<Domain.Entities.Eps> _epsRepository;

    public EpsChangeStateCommandHandler(EpsService epsService,
        IGenericRepository<Domain.Entities.Eps> epsRepository, IMapper mapper)
    {
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
        _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
    }

    public async Task<Unit> Handle(EpsChangeStateCommand request, CancellationToken cancellationToken)
    {
        await _epsService.Update(request.Id, request.newName);
        return Unit.Value;
    }
}