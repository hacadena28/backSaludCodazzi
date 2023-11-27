using Application.UseCases.Users.Queries.GetPaginationUser;
using Domain.Enums;

namespace Application.UseCases.Users.Queries.GetUserByDocumentNumber;

public record UserByDocumentNumberQuery(string DocumentNumber,Role role) : IRequest<UserDto>;