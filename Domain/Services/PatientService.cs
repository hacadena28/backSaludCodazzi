using Domain.Entities;
using Domain.Exceptions;
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

    public async Task<Patient> GetById(Guid patientId)
    {
        return await _patientRepository.GetByIdAsync(patientId);
    }

    public async Task UpdatePatient(Guid id, string firstName, string secondName, string lastName,
        string secondLastName, string email, string phone,
        string address)
    {
        var patientSearched = await _patientRepository.GetByIdAsync(id);
        _ = patientSearched ?? throw new CoreBusinessException(Messages.AlredyExistException);

        patientSearched.Update(firstName, secondName, lastName, secondLastName, email, phone, address);

        await _patientRepository.UpdateAsync(patientSearched);
    }
}