using Application.UseCases.Epses.Queries.GetEps;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Epses.Queries.GetEpsByID;

public class EpsByIdQueryHandler : IRequestHandler<EpsByIdQuery, EpsDto>
{
    private readonly IGenericRepository<Eps> _repository;
    private readonly EpsService _epsServices;
    private readonly IMapper _mapper;

    public EpsByIdQueryHandler(IGenericRepository<Eps>? repository, EpsService epsServices,
        IMapper mapper) =>
        (_repository, _epsServices, _mapper) = (repository, epsServices, mapper);

    public async Task<EpsDto> Handle(EpsByIdQuery request, CancellationToken cancellationToken)
    {
        var epsFilterById = await _epsServices.GetById(request.Id);
        var data = _mapper.Map<EpsDto>(epsFilterById);
        return data;
    }
}