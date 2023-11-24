using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class DoctorService
{
    private readonly IGenericRepository<Doctor> _doctorRepository;

    public DoctorService(IGenericRepository<Doctor> doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Doctor> GetById(Guid doctorId)
    {
        return await _doctorRepository.GetByIdAsync(doctorId);
    }

    public async Task<Doctor> GetDoctorByDocumentNumber(string documentNumber)
    {
        var response = await _doctorRepository.GetPagedFilterAsync(
            page: 1,
            pageSize: 20,
            filter: d => d.DocumentNumber == documentNumber,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false
        );

        return response.Records.FirstOrDefault();
    }

    public async Task UpdateDoctor(Guid id, string firstName, string secondName, string lastName,
        string secondLastName, string email, string phone,
        string address)
    {
        var doctorSearched = await _doctorRepository.GetByIdAsync(id);
        _ = doctorSearched ?? throw new CoreBusinessException(Messages.ResourceNotFoundException);
        doctorSearched.Update(firstName, secondName, lastName, secondLastName, email, phone, address);
        await _doctorRepository.UpdateAsync(doctorSearched);
    }
}