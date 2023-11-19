using Application.Common.Helpers;
using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Patients.Queries.GetPatient;

public record PatientQuery : RequestPagination, IRequest<ResponsePagination<PatientDto>>;