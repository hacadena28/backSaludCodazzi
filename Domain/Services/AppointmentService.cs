using Domain.Entities;
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

    public async Task CreateAppointment(Appointment appointment)
    {
        await _appointmentRepository.AddAsync(appointment);
    }
    public async Task<Appointment> GetById(Appointment appointment)
    {
        return await _appointmentRepository.GetByIdAsync(appointment.Id);
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        await _appointmentRepository.UpdateAsync(appointment);
    }

    public async Task DeleteAppointment(Appointment appointment)
    {
        await _appointmentRepository.DeleteAsync(appointment);
    }
}