using Application.Common.Helpers.Pagination;

namespace Application.UseCases.Users.Queries.GetPaginationUser;

public record PaginationUserQuery : RequestPagination, IRequest<ResponsePagination<UserDto>>;