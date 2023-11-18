using Application.UseCases.Patients.Queries.GetPatient;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Patients.Commands.PatientUpdate
{
    public class PatientUpdateCommandHandler : IRequestHandler<PatientUpdateCommand, PatientDto>
    {
        private readonly PatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.Patient> _patientRepository;

        public PatientUpdateCommandHandler(PatientService patientService,
            IGenericRepository<Domain.Entities.Patient> patientRepository, IMapper mapper)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
        }

        public async Task<PatientDto> Handle(PatientUpdateCommand request, CancellationToken cancellationToken)
        {
            var existingPatient = await _patientRepository.GetByIdAsync(request.Id);

            if (existingPatient == null)
            {
                throw new Exception("El paciente no se encontró o no existe.");
            }

            if (existingPatient.Id == request.Id)
            {
                existingPatient.FirstName = request.firstName;
                existingPatient.SecondName = request.secondName;
                existingPatient.LastName = request.lastName;
                existingPatient.SecondLastName = request.secondLastName;
                existingPatient.DocumentType = request.documentType;
                existingPatient.DocumentNumber = request.documentNumber;
                existingPatient.Email = request.email;
                existingPatient.Phone = request.phone;
                existingPatient.Address = request.address;
                existingPatient.Birthdate = request.birthdate;


                await _patientService.UpdatePatient(existingPatient);

                var updatedPatient = await _patientRepository.GetByIdAsync(request.Id);

                return _mapper.Map<PatientDto>(updatedPatient);
            }
            else
            {
                throw new Exception("Los id No Coinciden");
            }
        }
    }
}