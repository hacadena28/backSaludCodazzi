using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Medics.Queries.GetDoctor;

public record PaginationDoctorQuery : RequestPagination, IRequest<ResponsePagination<DoctorDto>>;