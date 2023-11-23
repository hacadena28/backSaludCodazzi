using Application.Common.Helpers.Pagination;

namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

public record PaginationMedicalHistoryQuery : RequestPagination, IRequest<ResponsePagination<MedicalHistoryDto>>;