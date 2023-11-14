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

    public async Task CreateMedicalHistory(MedicalHistory medicalHistory)
    {
        await _medicalHistoryRepository.AddAsync(medicalHistory);
    }
    public async Task<MedicalHistory> GetById(MedicalHistory medicalHistory)
    {
        return await _medicalHistoryRepository.GetByIdAsync(medicalHistory.Id);
    }

    public async Task UpdateMedicalHistory(MedicalHistory medicalHistory)
    {
        await _medicalHistoryRepository.UpdateAsync(medicalHistory);
    }

    public async Task DeleteMedicalHistory(MedicalHistory medicalHistory)
    {
        await _medicalHistoryRepository.DeleteAsync(medicalHistory);
    }
}