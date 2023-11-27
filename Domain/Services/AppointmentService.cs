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

    public async Task<Appointment> GetById(Guid appointmentId)
    {
        return await _appointmentRepository.GetByIdAsync(appointmentId);
    }

    public async Task<PagedResult<Appointment>> GetByPatientId(Guid patientId, int page, int pageSize)
    {
        var result = await _appointmentRepository.GetPagedFilterAsync(
            page: page,
            pageSize: pageSize,
            filter: e => e.PatientId == patientId,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false);

        return result;
    }

    public async Task<PagedResult<Appointment>> GetByDoctorId(Guid doctorId, int page, int pageSize)
    {
        var result = await _appointmentRepository.GetPagedFilterAsync(
            page: page,
            pageSize: pageSize,
            filter: e => e.DoctorId == doctorId,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false);

        return result;
    }

    public async Task Delete(Appointment appointment)
    {
        await _appointmentRepository.DeleteAsync(appointment);
    }

    public async Task ChangeStateAppointment(Guid id, AppointmentState state, DateTime? newDate)
    {
        var appointmentSearched = await _appointmentRepository.GetByIdAsync(id);
        _ = appointmentSearched ?? throw new CoreBusinessException(Messages.ResourceNotFoundException);
        if (state.Equals(AppointmentState.Canceled))
        {
            appointmentSearched.CancelAppointment();
        }
        else if (state.Equals(AppointmentState.Rescheduled))
        {
            if (newDate.HasValue)
            {
                appointmentSearched.RescheduleAppointment(newDate.Value);
            }
        }
        else if (state.Equals(AppointmentState.Attended))
        {
            appointmentSearched.AppointmentAttended();
        }
        else
        {
            throw new CoreBusinessException("No se puede cambiar el estado a una cita ya atendida");
        }

        await _appointmentRepository.UpdateAsync(appointmentSearched);
    }
}