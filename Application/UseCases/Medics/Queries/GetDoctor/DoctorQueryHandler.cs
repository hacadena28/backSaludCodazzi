using Domain.Ports;

namespace Application.UseCases.Medics.Queries.GetDoctor;

public class DoctorQueryHandler : IRequestHandler<DoctorQuery, List<DoctorDto>>
{
    private readonly IGenericRepository<Domain.Entities.Doctor> _repository;
    private readonly IMapper _mapper;

    public DoctorQueryHandler(IGenericRepository<Domain.Entities.Doctor>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<List<DoctorDto>> Handle(DoctorQuery request, CancellationToken cancellationToken)
    {
        var patient = (await _repository.GetAsync()).ToList();
        return _mapper.Map<List<DoctorDto>>(patient);
    }
}