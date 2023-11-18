using Domain.Ports;

namespace Application.UseCases.Epses.Queries.GetEps;

public class EpsQueryHandler : IRequestHandler<EpsQuery, List<EpsDto>>
{
    private readonly IGenericRepository<Domain.Entities.Eps> _repository;
    private readonly IMapper _mapper;

    public EpsQueryHandler(IGenericRepository<Domain.Entities.Eps>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<List<EpsDto>> Handle(EpsQuery request, CancellationToken cancellationToken)
    {
        var eps = (await _repository.GetAsync()).ToList();
        return _mapper.Map<List<EpsDto>>(eps);
    }
}