using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Epses.Queries.GetEpsNormal;

public class GetAllEpsQueryHandler : IRequestHandler<GetAllEpsQuery, IEnumerable<EpsNormalDto>>
{
    private readonly IGenericRepository<Eps> _repository;
    private readonly IMapper _mapper;

    public GetAllEpsQueryHandler(IGenericRepository<Eps> repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    public async Task<IEnumerable<EpsNormalDto>> Handle(GetAllEpsQuery request, CancellationToken cancellationToken)
    {
        var epssPaginated = await _repository.GetAsync();
        return _mapper.Map<List<EpsNormalDto>>(epssPaginated);
    }
}