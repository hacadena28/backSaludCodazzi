using Domain.Enums;

namespace Application.UseCases.Users.Queries.GetUser;

public record UserDto(Guid Id, Role Role);