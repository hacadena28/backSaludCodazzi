using Domain.Enums;

namespace Domain.Entities;

public class Appointment : EntityBase<Guid>
{
    public DateTime Date { get; set; }
    public AppointmentState State { get; set; }
    public TypeAppointment Type { get; set; }
    public string Description { get; set; }

    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }

    public Appointment
    (
        DateTime date,
        AppointmentState state,
        TypeAppointment type,
        string description,
        Guid patientId,
        Guid doctorId
    )
    {
        Date = date;
        State = state;
        Type = type;
        Description = description;
        PatientId = patientId;
        DoctorId = doctorId;
    }

    public Appointment()
    {
    }

    public void Update(DateTime? newDate, AppointmentState? state)
    {
        if (newDate.HasValue)
        {
            ChangeDate(newDate.Value);
        }
        if (state != null && !State.Equals(state)) State = (AppointmentState)state;
    }

    private void ChangeDate(DateTime newDate)
    {
        if (newDate != null && !Date.Equals(newDate))
        {
            if ((newDate - DateTime.Today).TotalDays <= 1)
            {
                throw new Exception("La nueva fecha de la cita debe ser al menos un día posterior a la fecha actual.");
            }

            Date = newDate;
        }
    }
}