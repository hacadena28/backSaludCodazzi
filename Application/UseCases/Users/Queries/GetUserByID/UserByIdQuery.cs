using Application.UseCases.Users.Queries.GetPaginationUser;

namespace Application.UseCases.Users.Queries.GetUserByID;

public record UserByIdQuery(Guid Id) : IRequest<UserDto>;