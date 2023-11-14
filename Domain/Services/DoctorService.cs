using Domain.Entities;
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

    public async Task CreateDoctor(Doctor doctor)
    {
        await _doctorRepository.AddAsync(doctor);
    }

    public async Task<Doctor> GetById(Doctor doctor)
    {
        return await _doctorRepository.GetByIdAsync(doctor.Id);
    }

    public async Task UpdateDoctor(Doctor doctor)
    {
        await _doctorRepository.UpdateAsync(doctor);
    }

    public async Task DeleteDoctor(Doctor doctor)
    {
        await _doctorRepository.DeleteAsync(doctor);
    }
}