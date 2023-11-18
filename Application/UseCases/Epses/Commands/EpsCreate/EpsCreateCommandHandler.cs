using Domain.Services;

namespace Application.UseCases.Epses.Commands.EpsCreate;

public class EpsCreateCommandHandler : IRequestHandler<EpsCreateCommand>
{
    private readonly EpsService _service;
    private readonly IMapper _mapper;

    public EpsCreateCommandHandler(EpsService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(EpsCreateCommand request, CancellationToken cancellationToken)
    {
        var eps = new Domain.Entities.Eps(request.Name);
        await _service.CreateEps(eps);
        return Unit.Value;
    }
}