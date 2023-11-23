using Domain.Enums;

namespace Application.UseCases.Users.Queries.GetPaginationUser;

public record UserDto(Guid Id, Role Role);