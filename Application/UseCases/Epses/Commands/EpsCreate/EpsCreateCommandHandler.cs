using Domain.Entities;
using Domain.Services;

namespace Application.UseCases.Epses.Commands.EpsCreate;

public class EpsCreateCommandHandler : IRequestHandler<EpsCreateCommand>
{
    private readonly EpsService _service;

    public EpsCreateCommandHandler(EpsService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(EpsCreateCommand request, CancellationToken cancellationToken)
    {
        var eps = new Eps(request.Name.Trim());
        await _service.CreateEps(eps);
        return Unit.Value;
    }
}