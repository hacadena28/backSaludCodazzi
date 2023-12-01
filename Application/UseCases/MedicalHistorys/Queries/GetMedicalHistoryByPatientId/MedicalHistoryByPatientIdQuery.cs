using Application.Common.Helpers.Pagination;
using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistoryByPatientId;

public record MedicalHistoryByPatientIdQuery(Guid PatientId) : RequestPagination,
    IRequest<ResponsePagination<MedicalHistoryDto>>;