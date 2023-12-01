using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistoryByID;

public record MedicalHistoryByIdQuery(Guid Id) : IRequest<MedicalHistoryDto>;