using Application.UseCases.Epses.Queries.GetEps;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Epses.Queries.GetEpsByName;

public class EpsByNameQueryHandler : IRequestHandler<EpsByNameQuery, EpsDto>
{
    private readonly IGenericRepository<Eps> _repository;
    private readonly EpsService _epsServices;
    private readonly IMapper _mapper;

    public EpsByNameQueryHandler(IGenericRepository<Eps>? repository, EpsService epsServices,
        IMapper mapper) =>
        (_repository, _epsServices, _mapper) = (repository, epsServices, mapper);

    public async Task<EpsDto> Handle(EpsByNameQuery request, CancellationToken cancellationToken)
    {
        var epsFilterByName = await _epsServices.GetByName(request.Name);
        var data = _mapper.Map<EpsDto>(epsFilterByName);
        return data;
    }
}