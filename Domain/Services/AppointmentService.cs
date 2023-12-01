using System.Globalization;
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
        if (!BeAValidDate(appointment.AppointmentStartDate))
        {
            throw new InvalidDate(Messages.InvalidDate);
        }

        if (!BeInValidTimeSlot(appointment.AppointmentStartDate))
        {
            throw new DateOutOfRange(Messages.DateOutOfRange);
        }


        if (await DoctorAvailable(appointment.DoctorId, appointment.AppointmentStartDate))
        {
            await _appointmentRepository.AddAsync(appointment);
        }
        else
        {
            throw new DateNotAvailable(Messages.DateNotAvailable);
        }
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

    public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorByMonth(Guid doctorId, DateTime date)
    {
        DateTime startdate = new DateTime(date.Year, date.Month, date.Day);
        DateTime endDate = startdate.AddMonths(1).AddDays(-1).AddHours(23);


        var result = await _appointmentRepository.GetAsync(
            filter: a =>
                a.DoctorId == doctorId &&
                a.AppointmentStartDate >= date &&
                a.AppointmentStartDate <= endDate, isTracking: true);
        return result;
    }


    public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorByDay(Guid doctorId, DateTime date)
    {
        DateTime startDate = date.Date;
        DateTime endDate = date.Date.AddDays(1).AddTicks(-1);


        var result = await _appointmentRepository.GetAsync(filter: a =>
            a.DoctorId == doctorId &&
            a.AppointmentStartDate >= startDate &&
            a.AppointmentStartDate <= endDate, isTracking: true);
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
                if (!BeAValidDate(newDate.Value))
                {
                    throw new DateNotAvailable(Messages.DateNotAvailable);
                }

                if (!BeInValidTimeSlot(newDate.Value))
                {
                    throw new DateOutOfRange(Messages.DateOutOfRange);
                }

                appointmentSearched.RescheduleAppointment(newDate.Value);
            }
        }
        else if (state.Equals(AppointmentState.Attended))
        {
            appointmentSearched.AppointmentAttended();
        }
        else
        {
            throw new CannotChangeTheAlreadyAttendedStatus(Messages.CannotChangeTheAlreadyAttendedStatus);
        }

        await _appointmentRepository.UpdateAsync(appointmentSearched);
    }

    public async Task<bool> DoctorAvailable(Guid doctorId, DateTime date)
    {
        var existingAppointments = await _appointmentRepository
            .GetAsync(
                filter: a => a.DoctorId == doctorId
                             && a.State != AppointmentState.Canceled
                             && a.AppointmentStartDate <= date
                             && a.AppointmentFinalDate > date
            );

        return !existingAppointments.Any();
    }

    public async Task RecordMedicalHistory(Guid appointmentId, MedicalHistory medicalHistory)
    {
        var existingAppointments = await _appointmentRepository.GetByIdAsync(appointmentId);
        existingAppointments.RecordMedicalHistory(medicalHistory);
        await _appointmentRepository.UpdateAsync(existingAppointments);
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }

    private bool BeInValidTimeSlot(DateTime date)
    {
        return (date.Hour >= 8 && date.Hour < 12 && date.Minute % 30 == 0) ||
               (date.Hour >= 14 && date.Hour < 18 && date.Minute % 30 == 0);
    }
}