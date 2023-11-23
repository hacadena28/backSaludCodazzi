using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Epses.Queries.GetEps;

public record PaginationEpsQuery : RequestPagination, IRequest<ResponsePagination<EpsDto>>;