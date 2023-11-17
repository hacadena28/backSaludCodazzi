using Application.Common.Exceptions;
using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;


namespace Application.UseCases.Eps.Commands.EpsUpdate;

public class EpsChangeStateCommandHandler : IRequestHandler<EpsChangeStateCommand>
{
    private readonly EpsService _epsService;
    private readonly IGenericRepository<Domain.Entities.Eps> _epsRepository;
    private readonly IMapper _mapper;

    public EpsChangeStateCommandHandler(EpsService epsService,
        IGenericRepository<Domain.Entities.Eps> epsRepository, IMapper mapper)
    {
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
        _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(EpsChangeStateCommand request, CancellationToken cancellationToken)
    {
        var eps = await _epsRepository.GetByIdAsync(request.Id);
        eps.ChangeState();
        await _epsService.ChangeState(eps);
        return Unit.Value;
    }
}