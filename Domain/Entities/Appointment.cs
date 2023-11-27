using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Appointment : EntityBase<Guid>
{
    public DateTime Date { get; set; }
    public DateTime AppointmentStartDate { get; set; }
    public DateTime AppointmentFinalDate { get; set; }
    public AppointmentState State { get; set; }
    public TypeAppointment Type { get; set; }
    public string Description { get; set; }

    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; }
    public Guid? MedicalHistoryId { get; set; }
    public virtual MedicalHistory? MedicalHistory { get; set; }
    public Guid DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }

    public Appointment
    (
        DateTime appointmentStartDate,
        TypeAppointment type,
        string description,
        Guid patientId,
        Guid doctorId
    )
    {
        Date = DateTime.Now;
        AppointmentStartDate = appointmentStartDate;
        AppointmentFinalDate = AppointmentStartDate.AddMinutes(29);
        State = AppointmentState.Scheduled;
        Type = type;
        Description = description;
        PatientId = patientId;
        DoctorId = doctorId;
    }

    public Appointment()
    {
    }


    public void RescheduleAppointment(DateTime newDate)
    {
        if (State.Equals(AppointmentState.Scheduled))
        {
            if (newDate != null && !Date.Equals(newDate))
            {
                if ((newDate - DateTime.Today).TotalDays <= 1)
                {
                    throw new Exception(
                        "La nueva fecha de la cita debe ser al menos un día posterior a la fecha actual.");
                }

                Date = newDate;
                State = AppointmentState.Rescheduled;
            }
        }
        else
        {
            throw new CoreBusinessException("Solo se puede reagendar citas que no esten reagendadas");
        }
    }

    public void CancelAppointment()
    {
        if (
            State.Equals(AppointmentState.Scheduled) ||
            State.Equals(AppointmentState.Rescheduled))
            State = AppointmentState.Canceled;
        else
        {
            throw new CoreBusinessException("No se puede Cancelar una cita ya atendida o cancelada");
        }
    }

    public void AppointmentAttended()
    {
        if (State.Equals(AppointmentState.Scheduled) ||
            State.Equals(AppointmentState.Rescheduled))
        {
            State = AppointmentState.Attended;
            AppointmentFinalDate = DateTime.Now;
        }
        else
        {
            throw new CoreBusinessException("No se puede cambiar el estado a una cita cancelada o atendida");
        }
    }
}