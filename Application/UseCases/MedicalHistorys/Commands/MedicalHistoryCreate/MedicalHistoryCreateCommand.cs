using Domain.Enums;

namespace Application.UseCases.MedicalHistorys.Commands.MedicalHistoryCreate;

public record MedicalHistoryCreateCommand(
    DateTime Date,
    string Description,
    string Diagnosis,
    string Treatment,
    Guid DoctorId,
    Guid PatientId
) : IRequest;