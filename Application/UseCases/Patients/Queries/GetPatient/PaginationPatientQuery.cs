using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Patients.Queries.GetPatient;

public record PaginationPatientQuery : RequestPagination, IRequest<ResponsePagination<PatientDto>>;