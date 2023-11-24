using Application.UseCases.Users.Queries.GetPaginationUser;

namespace Application.UseCases.Users.Queries.GetUserByDocumentNumber;

public record UserByDocumentNumberQuery(string DocumentNumber) : IRequest<UserDto>;