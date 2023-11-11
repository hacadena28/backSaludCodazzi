using Application.UseCases.Patient.Commands.PatientDelete;
using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Patient.Commands.PatientDelete
{
    public class PatientDeleteCommandHandler : IRequestHandler<PatientDeleteCommand, PatientDtoEmpty>
    {
        private readonly PatientService _epsService;
        private readonly IGenericRepository<Domain.Entities.Patient> _epsRepository;

        public PatientDeleteCommandHandler(PatientService epsService,
            IGenericRepository<Domain.Entities.Patient> epsRepository, IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        }

        public async Task<PatientDtoEmpty> Handle(PatientDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingPatient = await _epsRepository.GetByIdAsync(request.Id);

            if (existingPatient == null)
                return new PatientDtoEmpty();
            else
            {
                await _epsService.DeletePatient(existingPatient);
                return new PatientDtoEmpty();
            }
        }
    }
}