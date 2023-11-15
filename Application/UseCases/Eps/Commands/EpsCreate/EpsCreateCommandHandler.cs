using Application.UseCases.Eps.Queries.GetEps;
using Domain.Services;

namespace Application.UseCases.Eps.Commands.EpsCreate;

public class EpsCreateCommandHandler : IRequestHandler<EpsCreateCommand, EmptyEpsDto>
{
    private readonly EpsService _service;
    private readonly IMapper _mapper;

    public EpsCreateCommandHandler(EpsService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyEpsDto> Handle(EpsCreateCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateEps(
            _mapper.Map<Domain.Entities.Eps>(request)
        );
        return new EmptyEpsDto();
    }
}