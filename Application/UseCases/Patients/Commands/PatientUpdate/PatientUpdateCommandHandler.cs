using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Patients.Commands.PatientUpdate
{
    public class PatientUpdateCommandHandler : IRequestHandler<PatientUpdateCommand>
    {
        private readonly PatientService _patientService;
        private readonly IGenericRepository<Patient> _patientRepository;

        public PatientUpdateCommandHandler(PatientService patientService,
            IGenericRepository<Patient> patientRepository)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
        }

        public async Task<Unit> Handle(PatientUpdateCommand request, CancellationToken cancellationToken)
        {
            await _patientService.UpdatePatient(
                request.Id,
                request.FirstName?.Trim(),
                request.SecondName?.Trim(),
                request.LastName?.Trim(),
                request.SecondLastName?.Trim(),
                request.Email?.Trim(),
                request.Phone?.Trim(),
                request.Address?.Trim());

            return Unit.Value;
        }
    }
}