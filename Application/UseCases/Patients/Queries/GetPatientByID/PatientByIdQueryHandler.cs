using Application.UseCases.Patients.Queries.GetPatient;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Patients.Queries.GetPatientByID;

public class PatientByIdQueryHandler : IRequestHandler<PatientByIdQuery, PatientDto>
{
    private readonly IGenericRepository<Patient> _repository;
    private readonly PatientService _userServices;
    private readonly IMapper _mapper;

    public PatientByIdQueryHandler(IGenericRepository<Patient>? repository, PatientService userServices,
        IMapper mapper) =>
        (_repository, _userServices, _mapper) = (repository, userServices, mapper);

    public async Task<PatientDto> Handle(PatientByIdQuery request, CancellationToken cancellationToken)
    {
        var userFilterById = await _userServices.GetById(request.Id);
        var data = _mapper.Map<PatientDto>(userFilterById);
        return data;
    }
}