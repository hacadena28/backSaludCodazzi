namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

public record MedicalHistoryDto(Guid Id, DateTime Date, string Description, string Diagnosis, string Treatment,
    Guid PatientId);