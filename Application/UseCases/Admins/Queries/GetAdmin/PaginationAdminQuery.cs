using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Admins.Queries.GetAdmin;

public record PaginationAdminQuery : RequestPagination, IRequest<ResponsePagination<AdminDto>>;