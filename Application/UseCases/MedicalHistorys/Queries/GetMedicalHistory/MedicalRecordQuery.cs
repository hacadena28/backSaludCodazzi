namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

public record MedicalHistoryQuery : IRequest<List<MedicalHistoryDto>>;