using Application.Common.Helpers.Pagination;
using Application.UseCases.Users.Queries.GetPaginationUser;
using Domain.Enums;

namespace Application.UseCases.Users.Queries.GetUserPaginationByRol;

public record UserPaginatedByRolQuery(Role Role) : RequestPagination, IRequest<ResponsePagination<UserDto>>;