using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Application.UseCases.Epses.Commands.EpsCreate;

public class EpsCreateCommandHandler : IRequestHandler<EpsCreateCommand>
{
    private readonly EpsService _epsService;

    public EpsCreateCommandHandler(EpsService epsService)
    {
        _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
    }

    public async Task<Unit> Handle(EpsCreateCommand request, CancellationToken cancellationToken)
    {
        var searchedEps = await _epsService.GetByName(request.Name.Trim());
        if (searchedEps != null)
        {
            throw new AlreadyExistException(Domain.Messages.AlredyExistException);
        }

        var eps = new Eps(request.Name.Trim());
        await _epsService.CreateEps(eps);
        return Unit.Value;
    }
}