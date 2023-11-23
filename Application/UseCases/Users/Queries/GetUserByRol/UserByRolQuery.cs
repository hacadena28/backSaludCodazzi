using Application.UseCases.Users.Queries.GetPaginationUser;
using Domain.Enums;

namespace Application.UseCases.Users.Queries.GetUserByRol;

public record UserByRolQuery(Role Role) : IRequest<List<UserDto>>;