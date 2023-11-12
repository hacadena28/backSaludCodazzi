using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Users.Queries.GetUser;

public record UserDto(Guid Id, Role Role);