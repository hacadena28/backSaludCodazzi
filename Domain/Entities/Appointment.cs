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
        Patient patient,
        Doctor doctor
    )
    {
        Date = date;
        State = state;
        Type = type;
        Description = description;
        Patient = patient;
        Doctor = doctor;
    }

    public Appointment()
    {
    }
}