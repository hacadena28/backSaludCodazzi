using Domain.Enums;

namespace Domain.Entities;

public class MedicalHistory : EntityBase<Guid>
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }

    public Guid DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }
    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; }


    public MedicalHistory
    (
        DateTime date,
        string description,
        string diagnosis,
        string treatment,
        Guid doctorId,
        Guid patientId
    )
    {
        Date = date;
        Description = description;
        Diagnosis = diagnosis;
        Treatment = treatment;
        DoctorId = doctorId;
        PatientId = patientId;
    }

    public MedicalHistory()
    {
    }
}