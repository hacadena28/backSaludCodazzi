using Application.UseCases.Patients.Queries.GetPatient;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Patients.Queries.GetPatientByDocumentNumber;

public class PatientByDocumentNumberQueryHandler : IRequestHandler<PatientByDocumentNumberQuery, PatientDto>
{
    private readonly IGenericRepository<Patient> _repository;
    private readonly PatientService _patientServices;
    private readonly IMapper _mapper;

    public PatientByDocumentNumberQueryHandler(IGenericRepository<Patient>? repository, PatientService patientServices,
        IMapper mapper) =>
        (_repository, _patientServices, _mapper) = (repository, patientServices, mapper);

    public async Task<PatientDto> Handle(PatientByDocumentNumberQuery request, CancellationToken cancellationToken)
    {
        var patientFilterById = await _patientServices.GetPatientByDocumentNumber(request.DocumentNumber);
        var data = _mapper.Map<PatientDto>(patientFilterById);
        return data;
    }
}