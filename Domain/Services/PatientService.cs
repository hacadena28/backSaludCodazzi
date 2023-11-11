using Domain.Entities;
using Domain.Ports;



namespace Domain.Services;

[DomainService]
public class PatientService
{
    private readonly IGenericRepository<Patient> _patientRepository;

    public PatientService(IGenericRepository<Patient> patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task CreatePatient(Patient patient)
    {
        await _patientRepository.AddAsync(patient);
    }

    public async Task UpdatePatient(Patient patient)
    {
        await _patientRepository.UpdateAsync(patient);
    }

    public async Task DeletePatient(Patient patient)
    {
        await _patientRepository.DeleteAsync(patient);
    }
}