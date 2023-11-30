using Domain.Entities;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class MedicalHistoryService
{
    private readonly IGenericRepository<MedicalHistory> _medicalHistoryRepository;

    public MedicalHistoryService(IGenericRepository<MedicalHistory> medicalHistoryRepository)
    {
        _medicalHistoryRepository = medicalHistoryRepository;
    }

    public async Task Create(MedicalHistory medicalHistory)
    {
        await _medicalHistoryRepository.AddAsync(medicalHistory);
    }

    public async Task Update(Guid medicalHistoryId, string? description, string? diagnosis, string? treatment)
    {
        var existingMedicalHistory = _medicalHistoryRepository.GetByIdAsync(medicalHistoryId);
        // existingMedicalHistory.Update(description, diagnosis, treatment);

    }

    public async Task<MedicalHistory> GetById(MedicalHistory medicalHistory)
    {
        return await _medicalHistoryRepository.GetByIdAsync(medicalHistory.Id);
    }

    public async Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoryByPatientId(Guid patientId)
    {
        var result = await _medicalHistoryRepository.GetAsync(filter: a => a.PatientId == patientId, isTracking: true);
        return result;
    }
}