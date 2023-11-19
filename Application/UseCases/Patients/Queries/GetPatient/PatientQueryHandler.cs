using Domain.Ports;

namespace Application.UseCases.Patients.Queries.GetPatient;

public class PatientQueryHandler : IRequestHandler<PatientQuery, List<PatientDto>>
{
    private readonly IGenericRepository<Domain.Entities.Patient> _repository;
    private readonly IMapper _mapper;

    public PatientQueryHandler(IGenericRepository<Domain.Entities.Patient>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<List<PatientDto>> Handle(PatientQuery request, CancellationToken cancellationToken)
    {
        
        var patient = (await _repository.GetAsync()).ToList();
        return _mapper.Map<List<PatientDto>>(patient);
    }
}