using Domain.Enums;

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
        DateTime date,
        DateTime appointmentStartDate,
        TypeAppointment type,
        string description,
        Guid patientId,
        Guid doctorId
    )
    {
        Date = date;
        AppointmentStartDate = appointmentStartDate;
        AppointmentFinalDate = AppointmentStartDate.AddMinutes(30);
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
        if (newDate != null && !Date.Equals(newDate))
        {
            if ((newDate - DateTime.Today).TotalDays <= 1)
            {
                throw new Exception("La nueva fecha de la cita debe ser al menos un día posterior a la fecha actual.");
            }

            Date = newDate;
            State = AppointmentState.Rescheduled;
        }
    }

    public void CancelAppointment()
    {
        if (
            State.Equals(AppointmentState.Scheduled) ||
            State.Equals(AppointmentState.Rescheduled))
            State = AppointmentState.Canceled;
    }

    public void AppointmentAttended()
    {
        if (State.Equals(AppointmentState.Scheduled) ||
            State.Equals(AppointmentState.Rescheduled))
        {
            State = AppointmentState.Attended;
            AppointmentFinalDate = DateTime.Now;
        }
    }
}