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

    public async Task<MedicalHistory> GetById(MedicalHistory medicalHistory)
    {
        return await _medicalHistoryRepository.GetByIdAsync(medicalHistory.Id);
    }
}