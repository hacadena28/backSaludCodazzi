using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class MedicalHistoryBuilder
{
    private DateTime Date;
    private string Description;
    private string Diagnosis;
    private string Treatment;
    private Doctor Doctor;
    private Patient Patient;

    public MedicalHistoryBuilder WithDate(DateTime date)
    {
        Date = date;
        return this;
    }

    public MedicalHistoryBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }

    public MedicalHistoryBuilder WithDiagnosis(string diagnosis)
    {
        Diagnosis = diagnosis;
        return this;
    }

    public MedicalHistoryBuilder WithTreatment(string treatment)
    {
        Treatment = treatment;
        return this;
    }

    public MedicalHistoryBuilder WithDoctor(Doctor doctor)
    {
        Doctor = doctor;
        return this;
    }

    public MedicalHistoryBuilder WithPatient(Patient patient)
    {
        Patient = patient;
        return this;
    }

    public MedicalHistory Build()
    {
        return new MedicalHistory
        (
            Date,
            Description,
            Diagnosis,
            Treatment,
            Doctor,
            Patient
        );
    }
}