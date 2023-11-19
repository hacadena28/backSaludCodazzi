using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.MedicalHistorys.Commands.MedicalHistoryCreate;

public class MedicalHistoryCreateCommandHandler : IRequestHandler<MedicalHistoryCreateCommand>
{
    private readonly MedicalHistoryService _medicalHistoryServices;
    private readonly IGenericRepository<Doctor> _doctorRepository;
    private readonly IGenericRepository<Patient> _patientRepository;

    public MedicalHistoryCreateCommandHandler(MedicalHistoryService medicalHistoryServices,
        IGenericRepository<Patient> patientRepository, IGenericRepository<Doctor> doctorRepository)
    {
        _medicalHistoryServices =
            medicalHistoryServices ?? throw new ArgumentNullException(nameof(medicalHistoryServices));
        _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
    }

    public async Task<Unit> Handle(MedicalHistoryCreateCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);

        if (doctor == null || patient == null)
        {
            throw new CoreBusinessException("La etidad patient o doctor no existe");
        }

        var medicalHistory = new MedicalHistory
        (
            request.Date,
            request.Description,
            request.Diagnosis,
            request.Treatment,
            request.DoctorId,
            request.PatientId
        );

        await _medicalHistoryServices.Create(medicalHistory);

        return Unit.Value;
    }
}