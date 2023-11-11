using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Services;

namespace Application.UseCases.Patient.Commands.PatientCreate;

public class PatientCreateCommandHandler : IRequestHandler<PatientCreateCommand, PatientDtoEmpty>
{
    private readonly PatientService _service;
    private readonly IMapper _mapper;

    public PatientCreateCommandHandler(PatientService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PatientDtoEmpty> Handle(PatientCreateCommand request, CancellationToken cancellationToken)
    {
        await _service.CreatePatient(
            new Domain.Entities.Patient(request.firstName, request.secondName, request.lastName, request.secondLastName,request.documentType,request.documentNumber,request.email,request.phone,request.address,request.birthdate)
        );
        return new PatientDtoEmpty();
    }
}