using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class AppointmentService
{
    private readonly IGenericRepository<Appointment> _appointmentRepository;

    public AppointmentService(IGenericRepository<Appointment> appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task Create(Appointment appointment)
    {
        await _appointmentRepository.AddAsync(appointment);
    }

    public async Task<Appointment> GetById(Appointment appointment)
    {
        return await _appointmentRepository.GetByIdAsync(appointment.Id);
    }

    public async Task Update(Guid id, DateTime newDate, AppointmentState state)
    {
        var appointmentSearched = await _appointmentRepository.GetByIdAsync(id);
        _ = appointmentSearched ?? throw new CoreBusinessException(Messages.ResourceNotFoundException);
        appointmentSearched.Update(newDate, state);

        await _appointmentRepository.UpdateAsync(appointmentSearched);
    }

    public async Task Delete(Appointment appointment)
    {
        await _appointmentRepository.DeleteAsync(appointment);
    }
}